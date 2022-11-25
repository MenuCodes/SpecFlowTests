using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsAutomation.Drivers
{
    public class SeleniumDriver
    {
        private readonly Lazy<IWebDriver> _lazydriver;
        private bool _isDisposed;

        public SeleniumDriver()
        {
            _lazydriver = new Lazy<IWebDriver>(SetUp);
        }

        public IWebDriver Current => _lazydriver.Value;
        public IWebDriver SetUp()
        {
            var chromeDriverSvc = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            var driver = new ChromeDriver(chromeDriverSvc, chromeOptions);
            return driver;
        }
        public void Dispose()
        {
            if (_isDisposed)
             {
                return;
            }

            if (_lazydriver.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}
