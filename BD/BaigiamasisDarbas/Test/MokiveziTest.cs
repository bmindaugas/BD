using NUnit.Framework;

namespace BaigiamasisDarbas.Test
{
    public class MokiveziTest : BaseTest
    {
        [Test]
        public static void TestSonaxPrice()
        {
            mokiveziHomePage.NavigateToPage();
            mokiveziHomePage.ClosePopUpWindow();
            mokiveziHomePage.CloseCookies();
            mokiveziHomePage.SearchByText("langų ploviklis Sonax");
            mokiveziSearchResultPage.SelectByHighestPrice();
            mokiveziSearchResultPage.OrderByHighestPrice();
            mokiveziSearchResultPage.VerifyPrice("15,51 € / vnt. 15,99 € / vnt.");
        }

        [Test]
        public static void Test3SonaxPrice()
        {
            mokiveziHomePage.NavigateToPage();
            mokiveziHomePage.ClosePopUpWindow();
            mokiveziHomePage.CloseCookies();
            mokiveziHomePage.SearchByText("langų ploviklis Sonax");
            mokiveziSearchResultPage.SelectByHighestPrice();
            mokiveziSearchResultPage.OrderByHighestPrice();
            mokiveziHomePage.NumberQuantity("3");
            mokiveziSearchResultPage.AddToCart();
            //mokiveziSearchResultPage.CloseCardPopup();
            mokiveziSearchResultPage.GoToCart();
            //mokiveziSearchResultPage.ClickPirktiPrekes();            
            //cartPage.InsertQuantity(3);
            //cartPage.ClickPirktiPrekesButton();
            cartPage.VerifyIfICanBuy(50);

        }
    }
}
