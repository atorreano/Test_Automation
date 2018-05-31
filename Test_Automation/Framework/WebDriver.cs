using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Automation.Framework
{
    abstract class WebDriver
    {
        public abstract IWebDriver GetWebDriver { get; }
    }
}
