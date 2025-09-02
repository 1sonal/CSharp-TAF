Feature: TCID_003_AddNewCustomer 
Background: 
    Given User navigate to "URL"
    And User is on login page of the website
	When User logs in using "email" and "password"
	And clicks on login button
	Then home page opens
  @UITest  
  Scenario: TCID_003_AddNewCustomer
    Given User is on home page
    When User click on "Customers" menu
	And click on "Customers" submenu
    And click on Add new button
    And User enter 'Email' and 'FirstName'
    And User clicks on Save button
    Then verify the added customer

