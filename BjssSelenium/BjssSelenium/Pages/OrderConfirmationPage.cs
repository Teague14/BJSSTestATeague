//using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;

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
