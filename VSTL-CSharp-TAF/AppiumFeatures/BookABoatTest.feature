Feature: BookABoatTest

@MobileApp_E2E_Test
Scenario: Moxsea_TC_00 Login trial-Unhappy flow
	Given Login page is open
	And User loads test data for "moxsea_TC_00_UnhappyFlow"
	When User enters "Username" and "Password" for login
	And User clicks on login button
	Then User can not login

@MobileApp_E2E_Test
Scenario: Moxsea_TC_01 Verify user can Login and launch the App
	Given User is on login page
	And User loads test data for "moxsea_TC_01_LoginTest"
	When User enters "Username" and "Password"
	And User clicks on login button
	Then App is launched

@MobileApp_E2E_Test
Scenario Outline: Moxsea_TC_02 Verify options on Dashboard
	Given User is on Dashboard page
	Then User Verify '<options>' are visible on Dashboard
	
	Examples: 
	|options                |
	|Hamburg, Explor Club   |
	|Mallorca, Polar Club   |
	|Dubai, Golden Rib Club |

@MobileApp_E2E_Test
Scenario: Moxsea_TC_03 Verify Book A Boat Page Headers 
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

@MobileApp_E2E_Test
Scenario: Moxsea_TC_04 Verify Book A Boat Page Headers-Intentionally fail 
	Given User gets test data for "moxsea_TC_04_IntentionallyFail.xlsx"
	And  User is on Dashboard page
	When User click on a option on dashboard
	And User click on Book a boat option
	Then User verify Headers on Book A Boat Page
	| Headers  |
	| CALENDAR |
	| HARBOUR  |
	| BOAT1    |
	| ADD ON   |

























