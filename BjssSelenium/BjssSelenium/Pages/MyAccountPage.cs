using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class MyAccountPage:BaseClass
    {
        public MyAccountPage()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "sf-with-ul")]
        IWebElement menu { get; set; }  

        [FindsBy(How = How.XPath, Using = "//*[@id='center_column']/div/div[1]/ul/li[1]/a/span")]
        IWebElement btnOrderHistory { get; set; }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        /// <summary>
        /// Selects the dress type frm menu.
        /// </summary>
        /// <returns>The dress type frm menu.</returns>
        /// <param name="menuItem">Menu item.</param>
        public DressListPage SelectDressTypeFrmMenu(string menuItem)
        {
            Actions builder = new Actions(driver);
            builder.MoveToElement(menu).Build().Perform();
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.LinkText(menuItem)));
            IWebElement subMenu = driver.FindElement(By.LinkText(menuItem));
            subMenu.Click();
            return new DressListPage();
        }

        /// <summary>
        /// Clicks the order history button.
        /// </summary>
        /// <returns>The order history button.</returns>
        public OrderHistoryPage ClickOrderHistoryBtn()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(btnOrderHistory));
            btnOrderHistory.Click();
            return new OrderHistoryPage();
        }
    }
}
