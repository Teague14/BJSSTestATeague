using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BjssSelenium.Pages
{
    public class LoginPage:BaseClass
    {
        public LoginPage()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "email")]
        IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Name, Using = "passwd")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        IWebElement btnSubmit { get; set; }

        /// <summary>
        /// Login with specified userName and password.
        /// </summary>
        /// <returns>The login.</returns>
        /// <param name="userName">User name.</param>
        /// <param name="password">Password.</param>
        public MyAccountPage Login(string userName, string password)
        {
            txtEmail.SendKeys(userName);
            txtPassword.SendKeys(password);
            btnSubmit.Click();
            return new MyAccountPage();
        }
    }
}
