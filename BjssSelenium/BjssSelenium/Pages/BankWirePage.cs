using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class BankWirePage:BaseClass
    {
        public BankWirePage()
        {
            PageFactory.InitElements(driver, this);
        }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.XPath, Using = ("//*[@id='cart_navigation']/button/span"))]
        IWebElement btnConfirmOrder { get; set; }

        /// <summary>
        /// Confirms the order.
        /// </summary>
        /// <returns>The order.</returns>
        public OrderConfirmationPage ConfirmOrder()
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(btnConfirmOrder).Build().Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(btnConfirmOrder));
            btnConfirmOrder.Click();
            return new OrderConfirmationPage();
        }
    }
}
