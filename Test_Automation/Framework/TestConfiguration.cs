using NLog;
using System;
using static Test_Automation.Framework.BrowserUtil;

namespace Test_Automation.Framework
{
    public class TestConfiguration
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static TestConfiguration instance;

        private TestConfiguration()
        {
            // get any default info
        }

        public static TestConfiguration GetInstance()
        {
            logger.Info("Getting instance of TestConfiguration");

            if ( instance == null )
            {
                instance = new TestConfiguration();
            }

            return instance;
        }

        public Browser GetBrowser()
        {
            String property = System.Configuration.ConfigurationManager.AppSettings["browser"];
            logger.Info("TestConfiguration.GetBrowser() property: " + property);
            return BrowserUtil.GetInstance().GetBrowser(property);
        }

        public DriverType GetDriverType()
        {
            String property = System.Configuration.ConfigurationManager.AppSettings["webdriver-type"];
            logger.Info("TestConfiguration.GetDriverType() property: " + property);
            return BrowserUtil.GetInstance().GetDriverType(property);
        }

        public String GetSeleniumGridURL()
        {
            String property = System.Configuration.ConfigurationManager.AppSettings["selenium-grid-url"];
            logger.Info("TestConfiguration.GetSeleniumGridURL() property: " + property);
            return property;
        }

        public String GetSiteURL()
        {
            String property = System.Configuration.ConfigurationManager.AppSettings["site-url"];
            logger.Info("TestConfiguration.GetSiteURL() property: " + property);
            return property;
        }
    }
}
