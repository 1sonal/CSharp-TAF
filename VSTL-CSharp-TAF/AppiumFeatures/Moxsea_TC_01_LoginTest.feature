Feature: Moxsea_TC_01_LoginTest

User can verify login
@MobileAppTest
Scenario: Moxsea_TC_01 - Verify user can Login and launch the App
	Given User is on login page
	And User loads test data for "moxsea_TC_01_LoginTest"
	When User enters "Username" and "Password"
	And User clicks on login button
	Then App is launched

