using System;
using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class ShoppingCartPage:BaseClass
    {
        public ShoppingCartPage()
        {
            PageFactory.InitElements(driver, this);
        }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.Id, Using = "total_product")]
        IWebElement totalProducts { get; set; }

        [FindsBy(How = How.Id, Using = "total_price_without_tax")]
        IWebElement totalPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/p[2]/a[1]/span/i")]
        IWebElement btnProceedToCheckout { get; set; }

        public decimal shippingCost = 2.0m;

        /// <summary>
        /// Gets the size of the item.
        /// </summary>
        /// <returns>The item size.</returns>
        /// <param name="row">Row.</param>
        public string GetItemSize(int row)
        {
            var rowData = driver.FindElement(By.XPath("//*[@id='cart_summary']/tbody/tr[" + row + "]/td[2]/small[2]/a"));
            var size = rowData.Text;
            return size.Substring(size.Length - 1, 1);
        }

        /// <summary>
        /// Gets the item price.
        /// </summary>
        /// <returns>The item price.</returns>
        /// <param name="row">Row.</param>
        public decimal GetItemPrice(int row)
        {
            var rowData = driver.FindElement(By.XPath("//*[@id='cart_summary']/tbody/tr[" + row + "]/td[6]/span"));
            var cost = rowData.Text;
            return Convert.ToDecimal(cost.Substring(1, cost.Length - 1));
        }

        /// <summary>
        /// Gets the items total.
        /// </summary>
        /// <returns>The items total.</returns>
        public decimal GetItemsTotal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(totalProducts));
            var total = totalProducts.Text;
            return Convert.ToDecimal(total.Substring(1, total.Length - 1));
        }

        /// <summary>
        /// Gets the total price without tax.
        /// </summary>
        /// <returns>The total.</returns>
        public decimal GetTotal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(totalPrice));
            var total = totalPrice.Text;
            return Convert.ToDecimal(total.Substring(1, total.Length - 1));
        }

        /// <summary>
        /// Clicks the proceed to checkout button.
        /// </summary>
        /// <returns>The proceed to checkout.</returns>
        public AddressesPage ClickProceedToCheckout()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnProceedToCheckout));
            btnProceedToCheckout.Click();
            return new AddressesPage();
        }
    }
}
