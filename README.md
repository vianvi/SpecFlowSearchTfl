# SpecFlowSearchTfl

The aim of this project is setup basic UI automation framework using Specflow,C#, Selenium Webdriver and Chrome Driver.

## Setup
The template used is SpecFlow Project in Visual Studio.

## Approch

As this is develpoed for basic usage, added only created one feature file and one step file.
1) Native Nunit assertions used for verifications.
2) [BeforeScenario] and [AfterScenario] Hooks used to initiate and quit the driver.
3) For timing issues used selinium webriver wait.

## Issues encountered and sorted:
1) Identifying elements: tried to use CSS selectors where ever id's are not available.
2) Search criteria to supress  suggestions in From and To used KeyTabs.
3) Used waits to click buttons and search results text verification.

<To-Do>
In future move Hooks to seperate class file, instead of calling in each step defination.
Create driver class to initiate driver to run on multiple browsers.
Create Tags and env variables to run on different tests in different environments.
create reusable functions to use in step definition methods.
