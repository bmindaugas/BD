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
            mokiveziSearchResultPage.OrderByHighestPrice();
            mokiveziSearchResultPage.VerifyPrice("15,51 €");
        }

        [Test]
        public static void Test3SonaxPrice()
        {
            mokiveziHomePage.NavigateToPage();
            mokiveziHomePage.ClosePopUpWindow();
            mokiveziHomePage.CloseCookies();
            mokiveziHomePage.SearchByText("langų ploviklis Sonax");
            mokiveziSearchResultPage.OrderByHighestPrice();
            mokiveziSearchResultPage.AddToCart();
            mokiveziSearchResultPage.GoToCart();
            cartPage.ClickTestiApsipirkimaButton();
            cartPage.InsertQuantity(3);
            cartPage.VerifyIfICanBuy(50);

        }
    }
}
