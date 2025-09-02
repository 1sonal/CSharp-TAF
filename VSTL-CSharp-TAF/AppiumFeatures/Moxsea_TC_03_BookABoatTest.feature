Feature: Moxsea_TC_03_BookABoatTest

@MobileAppTest
Scenario: Moxsea_TC_03 - Verify Book A Boat Page Headers 
	Given User gets test data for "moxsea_TC_03_BookABoatTest"
	And  User is on Dashboard page
	When User click on a option on dashboard
	And User click on Book a boat option
	Then User verify Headers on Book A Boat Page
	| Headers  |
	| CALENDAR |
	| HARBOUR  |
	| BOAT     |
	| ADD ON   |