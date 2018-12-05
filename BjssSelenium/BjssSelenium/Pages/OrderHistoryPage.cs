using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Support.UI;

namespace BjssSelenium.Pages
{
    public class OrderHistoryPage : BaseClass
    {
        public OrderHistoryPage()
        {
            PageFactory.InitElements(driver, this);
        }

        WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));

        [FindsBy(How = How.XPath, Using = "//*[@id='sendOrderMessage']/p[2]/select")]
        IWebElement ddlProductList { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='sendOrderMessage']/p[3]/textarea")]
        IWebElement txtAddComment { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='sendOrderMessage']/div/button/span/i")]
        IWebElement btnSend { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='block-order-detail']/div[4]/div/div[1]/ul/li[7]/span")]
        IWebElement lblPhoneNumber { get; set; }

        /// <summary>
        /// Clicks the on order by date.
        /// </summary>
        /// <param name="date">Date.</param>
        public void ClickOnOrder(DateTime date)
        {
            int i = 1;
            var rowData = driver.FindElement(By.XPath("//*[@id='order-list']/tbody/tr[" + i + "]/td[2]"));
            string value = rowData.Text;
            while (value != date.ToString("MM/d/yyyy") || i > 10)
            {
                i++;
                rowData = driver.FindElement(By.XPath("//*[@id='order-list']/tbody/tr[" + i + "]/td[2]"));
                value = rowData.Text;
            }
            if (value == date.ToString("MM/d/yyyy"))
            {
                var linkTxt = driver.FindElement(By.XPath("//*[@id='order-list']/tbody/tr[" + i + "]/td[1]"));
                driver.FindElement(By.PartialLinkText(linkTxt.Text)).Click();
            }
        }

        /// <summary>
        /// Adds the comment to order.
        /// </summary>
        /// <param name="itemIndex">Item index.</param>
        /// <param name="comment">Comment.</param>
        public void AddCommentToOrder(int itemIndex, string comment)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ddlProductList));
            Actions action = new Actions(driver);
            action.MoveToElement(ddlProductList);
            action.Perform();
            ddlProductList.Click();
            driver.FindElement(By.XPath("//*[@id='sendOrderMessage']/p[2]/select/option[" + itemIndex + "]")).Click();
            txtAddComment.SendKeys(comment);
            btnSend.Click();
        }

        /// <summary>
        /// Checks the comment exists.
        /// </summary>
        /// <returns><c>true</c>, if comment exists was checked, <c>false</c> otherwise.</returns>
        /// <param name="comment">Comment.</param>
        public bool CheckCommentExists(string comment)
        {
            Thread.Sleep(2000);

            IWebElement table = driver.FindElement(By.XPath("//*[@id='block-order-detail']/div[5]/table/tbody"));
            ReadOnlyCollection<IWebElement> rows = table.FindElements(By.TagName("tr"));
            wait.Until(ExpectedConditions.ElementToBeClickable(table));
            Actions action = new Actions(driver);
            action.MoveToElement(rows[0]);
            action.Perform();
            foreach (var row in rows)
            {
                if (row.Text.Contains(comment))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the delivery phone number.
        /// </summary>
        /// <returns>The delivery phone number.</returns>
        public string GetDeliveryPhoneNumber()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(lblPhoneNumber));
            Actions action = new Actions(driver);
            action.MoveToElement(lblPhoneNumber);
            action.Perform();

            return lblPhoneNumber.Text;
        }
    }
}
