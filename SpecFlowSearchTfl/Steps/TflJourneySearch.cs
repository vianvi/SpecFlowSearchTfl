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


        [Given(@"I enter location in From field")]
        public void GivenIEnterLocationInFromField()
        {
            driver.FindElement(By.Id("InputFrom")).Click();
            driver.FindElement(By.Id("InputFrom")).SendKeys("Embankment Underground Station");
            driver.FindElement(By.Id("InputFrom")).SendKeys(Keys.Tab);
        }

        [Given(@"I enter location in To field")]
        public void GivenIEnterLocationInToField()
        {
            driver.FindElement(By.Id("InputTo")).Click();
            driver.FindElement(By.Id("InputTo")).SendKeys("Westminster Underground Station");
            driver.FindElement(By.Id("InputTo")).SendKeys(Keys.Tab);
        }
        [When(@"I click on plan my journey button")]
        public void WhenIClickOnPlanMyJourneyButton()
        {

            driver.FindElement(By.Id("plan-journey-button")).Click();
        }

        [Then(@"I verify the search results displayed")]
        public void ThenIVerifyTheSearchResultsDisplayed()
        {
            wait.Until(e => e.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")));
            Assert.That(driver.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")).Text, Is.EqualTo("Fastest by public transport"));

        }
        [Given(@"I enter invalid location in From field")]
        public void GivenIEnterInvalidLocationInFromField()
        {
            driver.FindElement(By.Id("InputFrom")).Click();
            driver.FindElement(By.Id("InputFrom")).SendKeys(",");
        }

        [Then(@"I verify the no searchresults message displayed")]
        public void ThenIVerifyTheNoSearchresultsMessageDisplayed()
        {
            wait.Until(e => e.FindElement(By.CssSelector(".field-validation-errors > .field-validation-error")));
            Assert.That(driver.FindElement(By.CssSelector(".field-validation-errors>.field-validation-error")).Text, Is.EqualTo("Sorry, we can\'t find a journey matching your criteria"));

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

        [Then(@"I enter new location in To field")]
        public void ThenIEnterNewLocationInToField()
        {
            driver.FindElement(By.Id("InputTo")).Click();
            driver.FindElement(By.Id("InputTo")).SendKeys("Ilford");
            driver.FindElement(By.Id("InputTo")).SendKeys(Keys.Tab);
        }

        [Then(@"I verify new search results")]
        public void ThenIVerifyNewSearchResults()
        {
            driver.FindElement(By.Id("plan-journey-button")).Click();
            wait.Until(e => e.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")));
            Assert.That(driver.FindElement(By.CssSelector("h2.jp-result-transport.publictransport.clearfix")).Text, Is.EqualTo("Fastest by public transport"));

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

        [Then(@"I see search results")]
        public void ThenISeeSearchResults()
        {
            Assert.That(driver.FindElement(By.CssSelector(".jp-results-headline")).Text, Is.EqualTo("Journey results"));
        }

        [Then(@"I click on recents")]
        public void ThenIClickOnRecents()
        {
            driver.FindElement(By.LinkText("Plan a journey")).Click();
            wait.Until(e => e.FindElement(By.LinkText("Recents")));
            driver.FindElement(By.LinkText("Recents")).Click();
        }

        [Then(@"I verify recent search")]
        public void ThenIVerifyRecentSearch()
        {
            var elements = driver.FindElements(By.LinkText("Embankment Underground Station to Westminster Underground Station"));
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
