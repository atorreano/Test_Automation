using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System;
using static Test_Automation.Framework.BrowserUtil;

namespace Test_Automation.Framework
{
    public static class WebDriverFactory
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IWebDriver InitWebDriver()
        {
            TestConfiguration tc = TestConfiguration.GetInstance();
            return GetSeleniumInstance( tc.GetDriverType(), tc.GetBrowser() );
        }

        private static IWebDriver GetSeleniumInstance( DriverType driverType, Browser browser )
        {
            switch (driverType)
            {
                case DriverType.LOCAL:
                    logger.Info("DriverType is Local");
                    return GetLocalDriver(browser);
                case DriverType.REMOTE:
                    logger.Info("DriverType is Remote");
                    return GetRemoteDriver(browser);
                default:
                    logger.Info("DriverType is defaulting to Local");
                    return GetLocalDriver(browser);
            }
        }
  
        private static IWebDriver GetLocalDriver(Browser browser)
        {
            switch (browser)
            {
                case Browser.FIREFOX:
                    return new FirefoxDriver();
                case Browser.INTERNET_EXPLORER:
                    InternetExplorerOptions ieOption = new InternetExplorerOptions();
                    ieOption.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    ieOption.EnsureCleanSession = true;
                    ieOption.RequireWindowFocus = true;
                    return new InternetExplorerDriver(ieOption);
                case Browser.CHROME:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--disable-extensions");
                    return new ChromeDriver(chromeOptions);
                case Browser.PHANTOMJS:
                    return new PhantomJSDriver();
                default:
                    return new ChromeDriver();
            }
        }

        private static IWebDriver GetRemoteDriver(Browser browser)
        {
            TestConfiguration testConfiguration = TestConfiguration.GetInstance();
            String gridUrl = testConfiguration.GetSeleniumGridURL();

            DesiredCapabilities desiredCapabilities = null;
            switch (browser)
            {
                case Browser.CHROME:
                    desiredCapabilities = DesiredCapabilities.Chrome();
                    break;
                case Browser.EDGE:
                    desiredCapabilities = DesiredCapabilities.Edge();
                    break;
                case Browser.FIREFOX:
                    desiredCapabilities = DesiredCapabilities.Firefox();
                    break;
                case Browser.INTERNET_EXPLORER:
                    desiredCapabilities = DesiredCapabilities.InternetExplorer();
                    break;
                case Browser.PHANTOMJS:
                    desiredCapabilities = DesiredCapabilities.PhantomJS();
                    break;
            }
            desiredCapabilities.SetCapability("platform", "LINUX");

            try
            {
                return new RemoteWebDriver(new Uri(testConfiguration.GetSeleniumGridURL()), desiredCapabilities);
            }
            catch (SystemException e)
            {
                throw new SystemException(e.Message);
            }
        }
    }

}


