using BuggyCarsAutomation.Drivers;
using BuggyCarsAutomation.PageObjects;
using OpenQA.Selenium;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace BuggyCarsAutomation.StepDefinitions
{
    [Binding]
    public sealed class RegisterStepDefinitions
    {
        private readonly RegistrationObject regObj;

        public RegisterStepDefinitions(SeleniumDriver _driver)
        {
            regObj = new RegistrationObject(_driver.Current);
        }

        [Given(@"a visitor navigates to the registration page")]
        public void GivenAVisitorNavigatesToTheRegistrationPage()
        {
            regObj.NavigateToRegistration();
        }


        [When(@"he enters the '([^']*)' '([^']*)''([^']*)' with valid input")]
        public void WhenHeEntersTheRequiredRegistrationFieldsWithValidInput(string userName, string fName, string lName)
        {
            regObj.EnterRegDetails(userName,fName,lName);
        }

        [When(@"he creates a valid password")]
        public void WhenHeCreatesAValidPassword()
        {
            regObj.EnterAndConfirmPwd();
        }

        [When(@"he clicks the Register button")]
        public void WhenHeClicksTheRegisterButton()
        {
            regObj.ClickRegister();
        }


        [Then(@"he should see a success message")]
        public void ThenHeShouldSeeASuccessMessage()
        {
            regObj.VerifySuccessMessage();
        }

        [When(@"he enters the '([^']*)' '([^']*)''([^']*)' with valid inputs")]
        public void WhenHeEntersTheWithValidInputs(string userName, string fName, string lName)
        {
            regObj.EnterRegDetails(userName, fName, lName);
            regObj.EnterAndConfirmPwd();
            regObj.ClickRegister();
            regObj.VerifySuccessMessage();
        }


        [When(@"he enters a duplicate '([^']*)'")]
        public void WhenHeEntersADuplicateUsername(string userName)
        {
            regObj.EnterDuplicateUsername(userName);
        }
      
        [When(@"he enters the '([^']*)''([^']*)'")]
        public void WhenHeEntersThe(string fName, string lName)
        {
            regObj.EnterFnameLname(fName,lName);
        }

        [Then(@"he should see an error message")]
        public void ThenHeShouldSeeAnErrorMessage()
        {
            regObj.VerifyErrorMessage();
        }

        [Then(@"he Logs into the website as '([^']*)'")]
        public void ThenHeLogsIntoTheWebsiteAs(string userName)
        {
            regObj.Login(userName);
        }

        [Then(@"he should be successfully logged in")]
        public void ThenHeShouldBeSuccessfullyLoggedIn()
        {
            regObj.VerifySuccessfulLogin();
        }


    }
}