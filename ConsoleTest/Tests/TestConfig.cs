using System;
using System.IO;
using Framework.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Driver = DriverSingleton.GetDriver();
        }

        protected void MakeScreenshotWhenFail(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                throw;
            }
        }

        [TearDown]
        public void ClearDriver()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
