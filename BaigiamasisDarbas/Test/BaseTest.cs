using BaigiamasisDarbas.Drivers;
using BaigiamasisDarbas.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BaigiamasisDarbas.Test
{
    public class BaseTest
    {
        private static IWebDriver driver;
        protected static MokiveziSearchResultPage mokiveziSearchResultPage;
        protected static MokiveziHomePage mokiveziHomePage;
        protected static CartPage cartPage;
        


        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            mokiveziSearchResultPage = new MokiveziSearchResultPage(driver);
            mokiveziHomePage = new MokiveziHomePage(driver);
            cartPage = new CartPage(driver);

        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
