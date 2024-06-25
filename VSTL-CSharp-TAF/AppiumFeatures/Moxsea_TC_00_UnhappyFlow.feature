Feature: Moxsea_TC_00_UnhappyFlow

@MobileAppTest
Scenario: Moxsea_TC_00 Login trial-Unhappy flow
	Given Login page is open
	And User loads test data for "moxsea_TC_00_UnhappyFlow"
	When User enters "Username" and "Password" for login
	And User clicks on login button
	Then User can not login
