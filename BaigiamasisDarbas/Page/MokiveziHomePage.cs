using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaigiamasisDarbas.Page
{
    public class MokiveziHomePage : BasePage
    {
        private const string PageAddress = "https://www.mokivezi.lt";
        private IWebElement SearchField => Driver.FindElement(By.Id("search"));
        private IWebElement SearchIcon => Driver.FindElement(By.CssSelector(".btn.btn-primary.header-search-form__submit-btn.medium-link"));
        private IWebElement PopUpClose => Driver.FindElement(By.CssSelector(".omnisend-form-63285e2b018728915f150e04-close-action"));

        private IWebElement CookieButton => Driver.FindElement(By.CssSelector(".cookie-notice__btn.btn.btn-primary"));

        public MokiveziHomePage(IWebDriver webdriver) : base(webdriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
        }

        public void ClosePopUpWindow()
        {
            GetWait().Until(driver => driver.FindElement(By.Id("omnisend-form-63285e2b018728915f150e04-close-icon")));
            PopUpClose.Click();

        }
        public void CloseCookies()
        {
            GetWait().Until(driver => driver.FindElement(By.XPath("//button[text()='SUTINKU']")));
            CookieButton.Click();
        }

        public void SearchByText(string text)
        {
            SearchField.Click();
            SearchField.SendKeys(text);
            SearchIcon.Click();
        }
    }
}
