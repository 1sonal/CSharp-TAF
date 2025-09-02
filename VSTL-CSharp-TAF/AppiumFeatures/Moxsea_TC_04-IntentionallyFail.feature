Feature: Moxsea_TC_04-IntentionallyFail

@MobileAppTest
Scenario: Moxsea_TC_04 - Verify Book A Boat Page Headers-Intentionally fail 
	Given User is on Dashboard page
	And User gets test data for "moxsea_TC_04_IntentionallyFail.xlsx"
	When User click on a option on dashboard
	And User click on Book a boat option
	Then User verify Headers on Book A Boat Page
	| Headers  |
	| CALENDAR |
	| HARBOUR  |
	| BOAT1    |
	| ADD ON   |

