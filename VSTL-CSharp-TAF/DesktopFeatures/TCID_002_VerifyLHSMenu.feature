Feature: TCID_002_VerifyLHSMenu
Background: 
    Given User navigate to "URL"
    And User is on login page of the website
	When User logs in using "email" and "password"
	And clicks on login button
	Then home page opens

@UITest
Scenario: TCID_002_VerifyLHSMenu
	Given User is on home page
    Then User can verify following menu
      | menu               |
      | Catalog            |
      | Sales              |
      | Customers          |
      | Promotions         |
      | Content management |
      | Configuration      |
      | System             |
      | Reports            |
      | Help               |

