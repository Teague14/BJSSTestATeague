using System;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class PaymentMethodPage:BaseClass
    {
        public PaymentMethodPage()
        {
            PageFactory.InitElements(driver, this);
        }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.XPath, Using = ("//*[@id='HOOK_PAYMENT']/div[1]/div/p/a/span"))]
        IWebElement btnWirePayment { get; set; }

        /// <summary>
        /// Clicks the Pay By Wire Button.
        /// </summary>
        /// <returns>The by wire.</returns>
        public BankWirePage PayByWire()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnWirePayment));
            btnWirePayment.Click();
            return new BankWirePage();
        }
    }
}
