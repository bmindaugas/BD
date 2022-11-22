﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BaigiamasisDarbas.Page
{
    public class CartPage : BasePage
    {
        private IWebElement totalPriceElement => Driver.FindElement(By.CssSelector(".font-weight-bold"));
        private IWebElement clickPirktiPrekesButton => Driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/nav/div[3]/div/div[1]/div/div[2]/div[3]/a[1]"));
        public CartPage(IWebDriver webdriver) : base(webdriver) { }

        public void InsertQuantity(int quantity)
        {
            IWebElement quantityField = Driver.FindElement(By.CssSelector(".product-quantity__input.browser-no-arrows"));
            Actions action = new Actions(Driver);
            action.DoubleClick(quantityField);
            action.Build().Perform();
            quantityField.SendKeys(quantity.ToString());
            action.KeyDown(Keys.Enter);
            action.KeyUp(Keys.Enter);
            action.Build().Perform();
        }
        public void VerifyIfICanBuy(int moneyToSpent)
        {
            GetWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".notification notification--success")));
            double totalPrice = double.Parse(totalPriceElement.Text.Replace("€", ""));
            Assert.IsTrue(moneyToSpent > totalPrice, $"Cannot by 3 Sonax with 50€, total price is {totalPrice}");
        }

        public void ClickPirktiPrekesButton()
        {
            GetWait().Until(driver => driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/nav/div[3]/div/div[1]/div/div[2]/div[3]/a[1]")));
            clickPirktiPrekesButton.Click();

        }

    }
}
