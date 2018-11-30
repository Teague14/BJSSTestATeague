using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;

namespace BjssSelenium
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static IWebDriver driverfox;

        /// <summary>
        /// On test failure or exception will take a screenshot and store in Debug folder
        /// </summary>
        /// <param name="action">Action.</param>
        protected void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var screenshot = driver.TakeScreenshot();
                var filename = "test-" + DateTime.Now.ToString("MM-dd-yyy-HH-mm") + ".png";
                screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://automationpractice.com/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
