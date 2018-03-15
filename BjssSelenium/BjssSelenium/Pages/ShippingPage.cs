using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class ShippingPage:BaseClass
    {
        public ShippingPage()
        {
            PageFactory.InitElements(driver, this);
        }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.XPath, Using = ("//*[@id='form']/p/button/span/i"))]
        IWebElement btnProceedToCheckout { get; set; }

        [FindsBy(How = How.Id, Using = ("uniform-cgv"))]
        IWebElement ckBoxTnC { get; set; }

        /// <summary>
        /// Checks the Terms and Conditions checkbox.
        /// </summary>
        public void AgreeTnCs()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ckBoxTnC));
            ckBoxTnC.Click();
        }

        /// <summary>
        /// Proceed to checkout button click.
        /// </summary>
        /// <returns>The to checkout button click.</returns>
        public PaymentMethodPage ProceedToCheckoutBtnClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnProceedToCheckout));
            btnProceedToCheckout.Click();
            return new PaymentMethodPage();
        }
    }
}
