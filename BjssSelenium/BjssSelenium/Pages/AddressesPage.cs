using System;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class AddressesPage:BaseClass
    {
        public AddressesPage()
        {
            PageFactory.InitElements(driver, this);
        }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.XPath, Using = ("//*[@id='center_column']/form/p/button/span/i"))]
        IWebElement btnProceedToCheckout { get; set; }

        /// <summary>
        /// Clicks the Proceed to Checkout button.
        /// </summary>
        /// <returns>The to checkout button click.</returns>
        public ShippingPage ProceedToCheckoutBtnClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnProceedToCheckout));
            btnProceedToCheckout.Click();
            return new ShippingPage();
        }
    }
}
