using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BuggyCarsAutomation.PageObjects
{
    public class RegistrationObject
    {
        private const string Url = "https://buggy.justtestit.org/";
        private readonly IWebDriver driver;
        public const int TIMEOUT = 80;
        public string error;
        WebDriverWait wait;
        public RegistrationObject(IWebDriver _driver)
        {
            driver = _driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(TIMEOUT));
        }

        private By linkRegistration = By.PartialLinkText("Register");
        private By tbxUsername = By.Id("username");
        private By tbxFname = By.Id("firstName");
        private By tbxLname = By.Id("lastName");
        private By tbxPwd = By.Id("password");
        private By tbxConfirmpwd = By.Id("confirmPassword");
        private By btnRegister = By.XPath("//button[normalize-space()=\"Register\"]");
        private By lblSuccess = By.CssSelector("div[class*='result'][class*='alert']");
        private By lblDuplicateError = By.CssSelector("div[class*='result'][class*='alert']");
        private By tbxLoginName= By.Name("login");
        private By tbxLoginPwd = By.Name("password");
        private By btnLogin = By.XPath("//button[normalize-space()=\"Login\"]");
        private By linkLogout = By.PartialLinkText("Logout");

        //Navigate to the registration page
        public void NavigateToRegistration()
        {
            driver.FindElement(linkRegistration).Click();
        }

        //Enter username, firstname and lastname
        public string EnterRegDetails(string userName, string firstName, string lastName)
        {
            driver.FindElement(tbxUsername).SendKeys(userName);
            driver.FindElement(tbxFname).SendKeys(firstName);
            driver.FindElement(tbxLname).SendKeys(lastName);
            return userName;
        }
        //Enter and confirm password
        public void EnterAndConfirmPwd()
        {
            driver.FindElement(tbxPwd).SendKeys("Phoebe@1976");
            driver.FindElement(tbxConfirmpwd).SendKeys("Phoebe@1976");
        }

        //Click the register button
        public void ClickRegister()
        {
            driver.FindElement(btnRegister).Click();
        }

        //Verify the success Message
        public void VerifySuccessMessage()
        {
            // wait.Until(c => c.FindElement(lblSuccess));
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(lblSuccess).Displayed, "Registration is successful");
        }

        public void OpenUrl()
        {
            //Open the website in the browser if not already opened
            if (driver.Url != Url)
            {
                driver.Url = Url;
            }
        }

        //Enter the username
        public void EnterDuplicateUsername(string userName)
        {
            driver.FindElement(tbxUsername).SendKeys(userName);
        }

        //Enter the firstname and lastname
        public void EnterFnameLname(string fName, string lName)
        {
            driver.FindElement(tbxFname).SendKeys(fName);
            driver.FindElement(tbxLname).SendKeys(lName);
        }

        //Verify the duplucate error message
        public void VerifyErrorMessage()
        {
            //wait.Until(c => c.FindElement(lblDuplicateError));
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(lblDuplicateError).Displayed, "UsernameExistsException: User already exists");

        }

        //Login to the website
        public void Login(string userName)
        {
            driver.FindElement(tbxLoginName).SendKeys(userName);
            driver.FindElement(tbxLoginPwd).SendKeys("Phoebe@1976");
            driver.FindElement(btnLogin).Click();

        }

        //Verify if the user logged in successfully if the Logout button is displayed
        public void VerifySuccessfulLogin()
        {
            //wait.Until(c => c.FindElement(linkLogout));
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(linkLogout).Displayed);
        }
    }
}
