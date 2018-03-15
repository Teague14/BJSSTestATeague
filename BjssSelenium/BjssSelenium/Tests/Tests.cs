using System;
using BjssSelenium.Pages;
using NUnit.Framework;

namespace BjssSelenium
{
    [TestFixture]
    public class Tests : BaseClass
    {
        [Test]
        public void BuyTwoItems()
        {
            LandingPage landingPage = new LandingPage();
            LoginPage loginPage = landingPage.ClickSignIn();
            MyAccountPage myAccountPage =loginPage.Login("ateague@bjss.com", "BJSSTest");

            DressListPage dressListPage = myAccountPage.SelectDressTypeFrmMenu("Summer Dresses");
            dressListPage.QuickViewItemByIndex(3);
            var dress1Price = dressListPage.GetDressPrice();
            dressListPage.SelectDressSize(2);
            dressListPage.ClickAddToCart();
            dressListPage.ClickContinueShopping();
            dressListPage.QuickViewItemByIndex(2);
            var dress2Price = dressListPage.GetDressPrice();
            var dress2Size = dressListPage.GetDressSize();
            dressListPage.ClickAddToCart();

            ShoppingCartPage shopCartPage =  dressListPage.ClickProceedToCheckOut();
            string item1Size = shopCartPage.GetItemSize(1);
            string item2Size = shopCartPage.GetItemSize(2);
            decimal item1Price = shopCartPage.GetItemPrice(1);
            decimal item2Price = shopCartPage.GetItemPrice(2);
            decimal shopCartTotal = shopCartPage.GetItemsTotal();
            decimal total = shopCartPage.GetTotal();

            Assert.AreEqual(item1Size, "M");
            Assert.AreEqual(dress2Size, item2Size);
            Assert.AreEqual(dress1Price, item1Price);
            Assert.AreEqual(dress2Price, item2Price);
            decimal tp = item1Price + item2Price;
            Assert.IsTrue(tp == shopCartTotal);
            decimal totalPrice = tp + shopCartPage.shippingCost;
            Assert.IsTrue(totalPrice == total);

            AddressesPage addressesPage = shopCartPage.ClickProceedToCheckout();
            ShippingPage shippingPage = addressesPage.ProceedToCheckoutBtnClick();
            shippingPage.AgreeTnCs();
            PaymentMethodPage paymentMethodPage = shippingPage.ProceedToCheckoutBtnClick();
            BankWirePage bankWirePage = paymentMethodPage.PayByWire();
            OrderConfirmationPage orderConfirmationPage = bankWirePage.ConfirmOrder();
        }

        [Test]
        public void ReviewPreviousOrderAndAddComment()
        {
            LandingPage landingPage = new LandingPage();
            LoginPage loginPage = landingPage.ClickSignIn();
            MyAccountPage myAccountPage = loginPage.Login("ateague@bjss.com", "BJSSTest");

            OrderHistoryPage orderHistoryPage = myAccountPage.ClickOrderHistoryBtn();
            orderHistoryPage.ClickOnOrder(DateTime.Now.AddDays(-1));
            string date = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            orderHistoryPage.AddCommentToOrder(1, "Comment added: " + date);
            bool commentExists = orderHistoryPage.CheckCommentExists("Comment added: " + date);
            Assert.IsTrue(commentExists);
        }

        [Test]
        public void CaptureImages()
        {
            UITest(() =>
            {
                LandingPage landingPage = new LandingPage();
                LoginPage loginPage = landingPage.ClickSignIn();
                MyAccountPage myAccountPage = loginPage.Login("ateague@bjss.com", "BJSSTest");

                OrderHistoryPage orderHistoryPage = myAccountPage.ClickOrderHistoryBtn();
                orderHistoryPage.ClickOnOrder(DateTime.Now.AddDays(-1));
                string phone = orderHistoryPage.GetDeliveryPhoneNumber();
                Assert.AreSame("123", phone);
            });
        }
    }
}
