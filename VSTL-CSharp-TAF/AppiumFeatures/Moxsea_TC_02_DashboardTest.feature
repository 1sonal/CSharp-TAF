Feature: Moxsea_TC_02_DashboardTest
@MobileAppTest
Scenario Outline: Moxsea_TC_02_DashboardTest - Verify options on Dashboard
	Given User is on Dashboard page
	Then User Verify '<options>' are visible on Dashboard
	
	Examples: 
	|options                |
	|Hamburg, Explor Club   |
	|Mallorca, Polar Club   |
	|Dubai, Golden Rib Club |
