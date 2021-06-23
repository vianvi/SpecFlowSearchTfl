# TFL website – Journey Planner Search widget

The aim of this project is setup basic UI automation framework using Specflow,C#, Selenium Webdriver and Chrome Driver.

## Setup
The template used is SpecFlow Project in Visual Studio.

## Run
Run in Visual Studio Test Explorer.
Run command line : Project location `dotnet test` .

## Approch

As this is develpoed for basic usage, added only created one feature file and one step file.
1) Native Nunit assertions used for verifications.
2) [BeforeScenario] and [AfterScenario] Hooks used to initiate and quit the driver.
3) For timing issues used selinium webriver wait.

## Issues encountered and Sorted are:
1) Identifying elements: tried to use CSS selectors where ever id's are not available.
2) Search criteria to supress  suggestions in From and To used KeyTabs.
3) Used waits to click buttons and search results text verification.
4) Make sure correct version of selenium chrome driver downloaded from package manager.

## Improvements Required 
1) In future move Hooks to seperate class file, instead of calling in each step defination.
2) Create driver class to initiate driver to run on multiple browsers.
3) Create Tags and env variables to run on different tests in different environments.
4) Create reusable functions to use in step definition methods.

## Run Results

VS Test Explorer:

<img width="1320" alt="VS-Run" src="https://user-images.githubusercontent.com/30834324/123092721-b2e10500-d422-11eb-92b7-03157961eadf.png">

Terminal:

<img width="854" alt="Terminal-Run" src="https://user-images.githubusercontent.com/30834324/123092764-bf655d80-d422-11eb-9417-08b7fddf06db.png">

