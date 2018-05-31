using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Test_Automation.Framework;
using Test_Automation.Mappings;
using static Test_Automation.Framework.BrowserUtil;

namespace Test_Automation
{
    [TestFixture]
    [Parallelizable]
    public class UnitTest1
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
        public void TestRecentNews()
        {
            driver.Navigate().GoToUrl(tc.GetSiteURL());
            IWebElement element = driver.FindElement(By.XPath( tm.RecentNews() ));
            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { element });
            StringAssert.AreEqualIgnoringCase(element.Text, "Recent News:");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\temp\Temp.jpg");
        }

        [Test]
        public void TestAdamImage()
        {
            driver.Navigate().GoToUrl(tc.GetSiteURL());
            IWebElement e = driver.FindElement(By.XPath(tm.FamilyLink()));
            e.Click();
            IWebElement e2 = driver.FindElement(By.XPath(tm.AdamImage()));
            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { e2 });
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\temp\Temp1.jpg");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }



    [TestFixture]
    [Parallelizable]
    public class UnitTest2
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor javaScriptDriver;
        private string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: green"";";
        private TestConfiguration tc;
        private TorreanoMapping tm;

        [SetUp]
        public void SetUp()
        {
            _driver = WebDriverFactory.InitWebDriver();
            javaScriptDriver = (IJavaScriptExecutor)_driver;
            tc = TestConfiguration.GetInstance();
            tm = TorreanoMapping.GetInstance();
        }

        [Test]
        public void TestFynnLink()
        {
            _driver.Navigate().GoToUrl(tc.GetSiteURL());

            IWebElement element = _driver.FindElement(By.XPath( tm.FynnLink() ));
            element.Click();

            IWebElement element3 = _driver.FindElement(By.XPath( tm.FynnImage() ));
            StringAssert.AreEqualIgnoringCase(element3.Text, "55 Lbs.");
            javaScriptDriver.ExecuteScript(highlightJavascript, new object[] { element3 });

            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"C:\temp\Temp2.jpg");
            _driver.Quit();
        }
        
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
