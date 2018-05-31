using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using Test_Automation.Framework;
using Test_Automation.Mappings;

namespace Test_Automation.Tests
{
    [TestFixture]
    [Parallelizable]
    class TestLinks
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IWebDriver driver;
        private IJavaScriptExecutor javaScriptDriver;
        private string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: green"";";
        private TestConfiguration tc;
        private TorreanoMapping tm;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.InitWebDriver();
            javaScriptDriver = (IJavaScriptExecutor)driver;
            tc = TestConfiguration.GetInstance();
            tm = TorreanoMapping.GetInstance();
        }

        [Test]
        public void TestDownloadLink()
        {
            driver.Navigate().GoToUrl(tc.GetSiteURL());
            IWebElement e = driver.FindElement(By.XPath(tm.DownloadLink()));
            e.Click();

            IWebElement e2 = driver.FindElement(By.XPath(tm.DownloadTitle() ));

            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { e2 });
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\temp\Temp4.jpg");

            StringAssert.AreEqualIgnoringCase( e2.Text, "Index of /downloads" );
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
