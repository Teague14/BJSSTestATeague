using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace BjssSelenium.Pages
{
    public class LandingPage:BaseClass
    {
        public LandingPage()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "login")]
        IWebElement btnLogin { get; set; }

        /// <summary>
        /// Clicks the sign in button.
        /// </summary>
        /// <returns>The sign in.</returns>
        public LoginPage ClickSignIn()
        {
            btnLogin.Click();
            return new LoginPage();
        }
    }
}
