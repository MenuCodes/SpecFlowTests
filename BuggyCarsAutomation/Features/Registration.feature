Feature: Registration
As a visitor
I want to be able to register in the website
So that I can vote for a sport car


Scenario: Verify a successful registration
	
	Given a visitor navigates to the registration page
	When he enters the '<userName>' '<firstName>''<lastName >' with valid inputs
	And he creates a valid password
	And he clicks the Register button
	Then he should see a success message

	Examples: 
	| userName | firstName | lastName |
	| Sammy166   | Sammy    | Lee    |

Scenario: Verify unsuccessful registration when a duplicate username is used
	
	Given a visitor navigates to the registration page
	When he enters the '<userName>' '<firstName>''<lastName >' with valid inputs
	And he enters a duplicate '<duplicateUsername>'
	And he enters the '<firstName>''<lastName >'
	And he creates a valid password
	And he clicks the Register button
	Then he should see an error message

	Examples: 
	| userName | firstName | lastName | duplicateUsername |
	| Pascal399   | Pascal   | Deen     | Pascal399           |
	| SUMMER23 | Summer    | Smith    |  summer23      |
	
Scenario: Verify if a visitor who has successfully registered can login to the system

	Given a visitor navigates to the registration page
	When he enters the '<userName>' '<firstName>''<lastName >' with valid inputs
	And he creates a valid password
	And he clicks the Register button
	Then he should see a success message
	And he Logs into the website as '<userName>'
	Then he should be successfully logged in

	Examples: 
	| userName | firstName | lastName |
	| Sammy18097  | Sammy     | Lee      |