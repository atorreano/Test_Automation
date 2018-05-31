using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Test_Automation.Framework
{
    class FirefoxDriverImplementation : WebDriver
    {
        public override IWebDriver GetWebDriver
        {
            get
            {
                return new FirefoxDriver();
            }
        }
    }
}
