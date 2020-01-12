using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static GitHubAutomation.Services.TestDataReader;

namespace Framework.Driver
{
    class DriverSingleton
    {
        static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (Settings.Browser)
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver("D:\\bstu2019\\testing_webdrive");
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }


        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
