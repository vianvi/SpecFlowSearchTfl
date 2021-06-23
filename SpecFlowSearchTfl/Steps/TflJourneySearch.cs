using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowSearchTfl.Steps
{
    [Binding]
    public sealed class TflJourneySearch
    {
        String test_url = "https://tfl.gov.uk/";
        IWebDriver driver;
        WebDriverWait wait;

        private readonly ScenarioContext _scenarioContext;

        public TflJourneySearch(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [Given(@"I have URL")]
        public void GivenIHaveURL()
        {

            driver.Url = test_url;
            driver.Manage().Window.Maximize();

            System.Threading.Thread.Sleep(2000);
            //Accept cookies
            driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll")).Click();
            driver.FindElement(By.Id("cb-done-button")).Click();
        }
        
        [When(@"I click on plan my journey button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {

            driver.FindElement(By.Id("plan-journey-button")).Click();
        }

        [Then(@"I verify the (.*) in search results displayed")]
        public void ThenIVerifyTheInSearchResultsDisplayed(string Message)
        {
            wait.Until(e => e.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")));
            Assert.That(driver.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")).Text, Is.EqualTo(Message));

        }

        [Given(@"I enter invalid location in From field")]
        public void GivenIEnterInvalidLocationInFromField()
        {
            driver.FindElement(By.Id("InputFrom")).Click();
            driver.FindElement(By.Id("InputFrom")).SendKeys(",");
        }

        [Then(@"I verify the No search results (.*)")]
        public void ThenIVerifyTheNoSearchResults(string Message)
        {
            wait.Until(e => e.FindElement(By.CssSelector(".field-validation-errors > .field-validation-error")));
            Assert.That(driver.FindElement(By.CssSelector(".field-validation-errors>.field-validation-error")).Text, Is.EqualTo(Message));
        }

        [Given(@"I enter no location in From field")]
        public void GivenIEnterNoLocationInFromField()
        {
            driver.FindElement(By.Id("InputFrom")).Click();
            driver.FindElement(By.Id("InputFrom")).SendKeys(Keys.Tab);
        }

        [Given(@"I enter no location in To field")]
        public void GivenIEnterNoLocationInToField()
        {
            driver.FindElement(By.Id("InputTo")).Click();
            driver.FindElement(By.Id("InputTo")).SendKeys(Keys.Tab);
        }

        [Then(@"I see error message")]
        public void ThenISeeErrorMessage()
        {
            Assert.That(driver.FindElement(By.Id("InputFrom-error")).Text, Is.EqualTo("The From field is required."));
            Assert.That(driver.FindElement(By.Id("InputTo-error")).Text, Is.EqualTo("The To field is required."));

        }

        [Then(@"I click on amend journey in results page")]
        public void ThenIClickOnAmendJourneyInResultsPage()
        {
            driver.FindElement(By.CssSelector(".edit-journey > span")).Click();
        }

        [Then(@"I enter (.*) in To field")]
        public void ThenIEnterInToField(string NewToLocation)
        {
            driver.FindElement(By.Id("InputTo")).Click();
            driver.FindElement(By.Id("InputTo")).SendKeys(NewToLocation);
            driver.FindElement(By.Id("InputTo")).SendKeys(Keys.Tab);
        }
        [Then(@"I verify (.*) search results")]
        public void ThenIVerifySearchResults(string Message)
        {
            driver.FindElement(By.Id("plan-journey-button")).Click();
            wait.Until(e => e.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")));
            Assert.That(driver.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")).Text, Is.EqualTo(Message));

        }

        [Given(@"I enter location in from '(.*)' field")]
        public void GivenIEnterLocationInField(string From)
        {
            driver.FindElement(By.Id("InputFrom")).Click();
            driver.FindElement(By.Id("InputFrom")).SendKeys(From);
            driver.FindElement(By.Id("InputFrom")).SendKeys(Keys.Tab);
        }

        [Given(@"I enter location in to '(.*)' field")]
        public void GivenIEnterLocationInTField(string To)
        {
            driver.FindElement(By.Id("InputTo")).Click();
            driver.FindElement(By.Id("InputTo")).SendKeys(To);
            driver.FindElement(By.Id("InputTo")).SendKeys(Keys.Tab);
        }
        [Then(@"I see search results '(.*)'")]
        public void ThenISeeSearchResults(string Message)
        {
            Assert.That(driver.FindElement(By.CssSelector(".jp-results-headline")).Text, Is.EqualTo(Message));
        }

        [Then(@"I click on recents")]
        public void ThenIClickOnRecents()
        {
            driver.FindElement(By.LinkText("Plan a journey")).Click();
            wait.Until(e => e.FindElement(By.LinkText("Recents")));
            driver.FindElement(By.LinkText("Recents")).Click();
        }

        [Then(@"I  recent (.*) in search")]
        public void ThenIRecentInSearch(string VerifyJourneyLink)
        {
            var elements = driver.FindElements(By.LinkText(VerifyJourneyLink));
            Assert.True(elements.Count > 0);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
