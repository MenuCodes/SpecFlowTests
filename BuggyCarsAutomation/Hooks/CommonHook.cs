using BuggyCarsAutomation.Drivers;
using BuggyCarsAutomation.PageObjects;
using TechTalk.SpecFlow;

namespace BuggyCarsAutomation.Hooks
{
    [Binding]
    public sealed class CommonHook
    {

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(SeleniumDriver driver)
        {
            var regObj = new RegistrationObject(driver.Current);
            regObj.OpenUrl();
        }

        [AfterScenario]
        public void CloseDriver(SeleniumDriver driver)
        {
            driver.Dispose();
        }


    }
}