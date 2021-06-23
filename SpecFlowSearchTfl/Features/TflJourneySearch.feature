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
	And I enter location in from '<From>' field
	And I enter location in to '<To>' field
	When I click on plan my journey button
	Then I verify the <Message> in search results displayed
	Examples: 
	| From                           | To                             | Message                     |
	| Embankment Underground Station | Westminster Underground Station| Fastest by public transport |

Scenario: No Results For Invalid Journey
	Given I have URL
	And I enter location in from '<From>' field
	And I enter location in to '<To>' field
	When I click on plan my journey button
	Then I verify the No search results <Message>
	Examples: 
	| From | To                             | Message                     |
	| ,    | Westminster Underground Station| Sorry, we can't find a journey matching your criteria |

Scenario: Unable To Plan Journey For No Locations Entered
	Given I have URL
	And I enter no location in From field
	And I enter no location in To field
	When I click on plan my journey button
	Then I see error message

Scenario: Add Valid Locations And Amend The Journey
	Given I have URL
	And I enter location in from '<From>' field
	And I enter location in to '<To>' field
	When I click on plan my journey button
	Then I verify the <Message> in search results displayed
	And I click on amend journey in results page
	And I enter <NewLocation> in To field
	And I verify <Message> search results
	Examples: 
	| From                           | To                             | Message                     | NewLocation  | 
	| Embankment Underground Station | Westminster Underground Station| Fastest by public transport | Ilford        | 

Scenario: Check Recents Tab
	Given I have URL
	And I enter location in from '<From>' field
	And I enter location in to '<To>' field
	When I click on plan my journey button
	Then I verify the <Message> in search results displayed
	And I click on amend journey in results page
	And I enter <NewLocation> in To field
	And I click on recents
	And I  recent <VerifyJourneyLink> in search
	Examples: 
	| From                           | To                             | Message                     | NewLocation  | VerifyJourneyLink|
	| Embankment Underground Station | Westminster Underground Station| Fastest by public transport | Ilford        | Embankment Underground Station to Westminster Underground Station|
