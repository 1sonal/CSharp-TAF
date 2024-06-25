Feature: TCID_001_VerifyLoginFunctionality
Background: 
Given User navigate to "URL"

@UITest
Scenario: TCID_001_VerifyLoginFunctionality
	Given User is on login page of the website
	When User logs in using "email" and "password"
	And clicks on login button
	Then home page opens
