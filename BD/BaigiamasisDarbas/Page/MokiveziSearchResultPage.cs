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
        private IWebElement selectByHighestPriceText => Driver.FindElement(By.CssSelector(".text-capitalize")); //paspaudziu dropdown //span[text()='brangiausios viršuje']
        private IWebElement orderByHighestPriceText => Driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]/div/div/div[2]/div/a[5]")); //pasirenku auksciausia klaina jau surusiuota

        //private const string orderByHighestPriceText = "Brangiausios viršuje";
        private IWebElement closeCardPopup => Driver.FindElement(By.XPath("//button[@modal-close='cart-actions']"));
        private IWebElement goToCart => Driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/nav/div[3]/div/div[1]/div/div[1]"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".row.row--small-gutter.mt-5.product-catalog-container"));
        //private SelectElement orderByDropdown => new SelectElement(Driver.FindElement(By.CssSelector(".text-capitalize")));

        public MokiveziSearchResultPage(IWebDriver webdriver) : base(webdriver) { }

        //public void OrderByHighestPrice()
        //{
        //    GetWait().Until(driver => driver.FindElement(By.CssSelector(".text-capitalize")).Displayed);
        //    orderByDropdown.SelectByText(orderByHighestPriceText);
        //}



        public void SelectByHighestPrice()
        {
            GetWait().Until(driver => driver.FindElement(By.CssSelector(".text-capitalize")));
            selectByHighestPriceText.Click();
        }
        public void OrderByHighestPrice()
        {
            GetWait().Until(driver => driver.FindElement(By.XPath("/html/body/div[4]/div/div[1]/div/div/div[2]/div/a[5]")));
            orderByHighestPriceText.Click();
        }



        public void VerifyPrice(string price)
        {
            IWebElement firstResultElement = results.ElementAt(0);
            string firstResultElementPrice = firstResultElement.FindElement(By.XPath("//div[@itemprop='price']")).Text;
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

        public void CloseCardPopup()
        {
            GetWait().Until(driver => driver.FindElement(By.XPath("//button[@modal-close='cart-actions']")));
            closeCardPopup.Click();
        }

        public void GoToCart()
        {
            GetWait().Until(driver => driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/nav/div[3]/div/div[1]/div/div[1]")));
            goToCart.Click();
        }
    }
}
