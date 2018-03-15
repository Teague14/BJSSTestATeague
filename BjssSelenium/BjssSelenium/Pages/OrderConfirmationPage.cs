using OpenQA.Selenium.Support.PageObjects;

namespace BjssSelenium.Pages
{
    public class OrderConfirmationPage:BaseClass
    {
        public OrderConfirmationPage()
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
