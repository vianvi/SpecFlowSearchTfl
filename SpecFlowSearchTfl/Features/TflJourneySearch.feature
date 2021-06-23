Feature: TFL Journey Search

# @mytag
Scenario Outline: Verify With Different Sets Of Data
    Given I have URL
	And I enter location in from '<From>' field
	And I enter location in to '<To>' field
	When I click on plan my journey button
	Then I see search results '<Message>'
	Examples: 
	| From                    | To                    | Message         |
	| Westminister            | Ilford                | Journey results |
	| North Greenwich Station | North Wembley Station | Journey results |

Scenario: Add Valid Locations And Verify The Journey
	Given I have URL
	And I enter location in From field
	And I enter location in To field
	When I click on plan my journey button
	Then I verify the search results displayed

Scenario: No Results For Invalid Journey
	Given I have URL
	And I enter invalid location in From field
	And I enter location in To field
	When I click on plan my journey button
	Then I verify the no searchresults message displayed

Scenario: Unable To Plan Journey For No Locations Entered
	Given I have URL
	And I enter no location in From field
	And I enter no location in To field
	When I click on plan my journey button
	Then I see error message

Scenario: Add Valid Locations And Amend The Journey
	Given I have URL
	And I enter location in From field
	And I enter location in To field
	When I click on plan my journey button
	Then I verify the search results displayed
	And I click on amend journey in results page
	And I enter new location in To field
	And I verify new search results

Scenario: Check Recents Tab
	Given I have URL
	And I enter location in From field
	And I enter location in To field
	When I click on plan my journey button
	Then I verify the search results displayed
	And I click on amend journey in results page
	And I enter new location in To field
	And I click on recents
	And I verify recent search

