using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using NUnit.Core;

namespace SeleniumTests
{
    public class TestSuiteDyzurCreate
    {
        [Suite]
        public static TestSuite Suite
        {
            get
            {
                TestSuite suite = new TestSuite("TestSuiteDyzurCreate");
                suite.Add(new userLogin());
                suite.Add(new PracownikCreate());
                suite.Add(new OddzialCreate());
                suite.Add(new PlacowkaCreate());
                suite.Add(new DyzurCreate());
                return suite;
            }
        }
    }
}
