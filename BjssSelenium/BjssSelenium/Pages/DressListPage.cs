using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class DressListPage:BaseClass
    {
        public DressListPage()
        {
            PageFactory.InitElements(driver, this);
        }
        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/ul")]
        IWebElement dressList { get; set; } 

        [FindsBy(How = How.Id, Using = ("our_price_display"))]
        IWebElement displayPrice { get; set; }

        [FindsBy(How = How.XPath, Using = ("//*[@id='uniform-group_1']/span"))]
        IWebElement defaultSize { get; set; }

        [FindsBy(How = How.Id, Using = ("uniform-group_1"))]
        IWebElement ddlSize { get; set; }

        [FindsBy(How = How.Id, Using = ("add_to_cart"))]
        IWebElement btnAddToCart { get; set; }

        [FindsBy(How = How.XPath, Using = ("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span/span/i"))]
        IWebElement btnContShop { get; set; } 

        [FindsBy(How = How.XPath, Using = ("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a"))]
        IWebElement btnProceedToCo { get; set; } 

        /// <summary>
        /// Clicks the quick view link on the item provided index.
        /// </summary>
        /// <param name="index">Index.</param>
        public void QuickViewItemByIndex(int index)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(dressList);
            action.Perform();

            IWebElement quickview = driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[" + index + "]/div/div[1]/div/a[2]/span"));
            IWebElement dressPic = driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[" + index + "]/div/div[1]/div/a[1]/img"));

            // WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0,0,10)); 
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='center_column']/ul/li[" + index + "]/div/div[1]/div/a[1]/img")));

            Actions hover = new Actions(driver);
            hover.MoveToElement(dressPic).Perform();
            wait.Until(ExpectedConditions.ElementToBeClickable(quickview));
            quickview.Click();
            //Would like to find a slicker way to find elements on iFrame but none work so far
            Thread.Sleep(3000);
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("fancybox-iframe")));
        }

        /// <summary>
        /// Gets the dress price.
        /// </summary>
        /// <returns>The dress price.</returns>
        public decimal GetDressPrice()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(displayPrice));
            var cost = displayPrice.Text;
            return Convert.ToDecimal(cost.Substring(1, cost.Length - 1));
        }

        /// <summary>
        /// Gets the size of the dress.
        /// </summary>
        /// <returns>The dress size.</returns>
        public string GetDressSize()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(defaultSize));
            return defaultSize.Text;

        }

        /// <summary>
        /// Selects the size of the dress.
        /// </summary>
        /// <param name="size">Size.</param>
        public void SelectDressSize(int size)
        {
            ddlSize.Click();

            IWebElement sizeOption = driver.FindElement(By.XPath("//*[@id='group_1']/option[" + size + "]"));
            sizeOption.Click();
        }

        /// <summary>
        /// Clicks the add to cart button.
        /// </summary>
        public void ClickAddToCart()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnAddToCart));
            btnAddToCart.Click();
        }

        /// <summary>
        /// Clicks the continue shopping button.
        /// </summary>
        public void ClickContinueShopping()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnContShop));
            btnContShop.Click();
        }

        /// <summary>
        /// Clicks the proceed to check out button.
        /// </summary>
        /// <returns>The proceed to check out.</returns>
        public ShoppingCartPage ClickProceedToCheckOut()
        {
            IWebElement elementDisplayed = new WebDriverWait(driver, new TimeSpan(0, 0, 5)).Until(x => x.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")));
            //wait.Until(ExpectedConditions.ElementToBeClickable(btnProceedToCo));
            btnProceedToCo.Click();
            return new ShoppingCartPage();
        }
    }
}
