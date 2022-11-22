using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace BaigiamasisDarbas.Page
{
    public class MokiveziSearchResultPage : BasePage
    {
        private const string orderByHighestPriceText = "Brangiausios viršuje";
        private IWebElement goToCart => Driver.FindElement(By.CssSelector(".basket-btn__text.medium-link.mx-1.d-none.d-md-block"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".row.row--small-gutter.mt-5.product-catalog-container"));
        private SelectElement orderByDropdown => new SelectElement(Driver.FindElement(By.XPath("//span[text()='rasti produktai']")));

        public MokiveziSearchResultPage(IWebDriver webdriver) : base(webdriver) { }

        public void OrderByHighestPrice()
        {
            GetWait().Until(driver => driver.FindElement(By.XPath("//span[text()='rasti produktai']")).Displayed);
            orderByDropdown.SelectByText(orderByHighestPriceText);
        }

        public void VerifyPrice(string price)
        {
            IWebElement firstResultElement = results.ElementAt(0);
            string firstResultElementPrice = firstResultElement.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div[1]/div[1]/div/div[1]/div/div/div")).Text;
            Assert.AreEqual(price, firstResultElementPrice, "Price is wrong");
        }
        public void AddToCart()
        {
            IWebElement firstResultElement = results.ElementAt(0);
            Actions action = new Actions(Driver);
            IWebElement imageElement = firstResultElement.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div[1]/div[1]/div/div[1]/a"));
            action.MoveToElement(imageElement);
            action.Build().Perform();
            firstResultElement.FindElement(By.XPath("/html/body/div[4]/div/div[3]/div[1]/div[1]/div/div[2]/div/form/div[2]/div[2]/button[1]")).Click();
        }

        public void GoToCart()
        {
            GetWait().Until(driver => driver.FindElement(By.CssSelector(".basket-btn__text.medium-link.mx-1.d-none.d-md-block")));
            goToCart.Click();
        }
    }
}
