using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Test_Automation.Framework
{
    public class BrowserUtil
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static BrowserUtil instance;

        public enum Browser
        {
            CHROME,
            FIREFOX,
            PHANTOMJS,
            INTERNET_EXPLORER,
            EDGE
        }

        public enum DriverType
        {
            REMOTE,
            LOCAL
        }

        private BrowserUtil()
        {
            // get any default info
        }

        public static BrowserUtil GetInstance()
        {
            logger.Info("Getting instance of BrowserUtil");

            if (instance == null)
            {
                instance = new BrowserUtil();
            }

            return instance;
        }

        public Browser GetBrowser(String browser)
        {
            switch ((Browser)Enum.Parse(typeof(Browser), browser, true))
            {
                case Browser.CHROME:
                    return Browser.CHROME;
                case Browser.EDGE:
                    return Browser.EDGE;
                case Browser.FIREFOX:
                    return Browser.FIREFOX;
                case Browser.INTERNET_EXPLORER:
                    return Browser.INTERNET_EXPLORER;
                case Browser.PHANTOMJS:
                    return Browser.PHANTOMJS;
                default:
                    return Browser.CHROME;
            }
        }

        public DriverType GetDriverType(String driverType)
        {
            switch ((DriverType)Enum.Parse(typeof(DriverType), driverType, true))
            {
                case DriverType.LOCAL:
                    return DriverType.LOCAL;
                case DriverType.REMOTE:
                    return DriverType.REMOTE;
                default:
                    return DriverType.LOCAL;
            }
        }

        private IWebDriver GetRemoteDriver(Browser browserType)
        {
            TestConfiguration testConfiguration = TestConfiguration.GetInstance();
            String gridUrl = testConfiguration.GetSeleniumGridURL();

            DesiredCapabilities desiredCapabilities = null;
            switch (browserType)
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
