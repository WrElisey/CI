using Framework.Driver;
using Framework.Models;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace GitHubAutomation.Pages
{
    public class ProductPage
    {
        private string currencySelector = ".currency-list a[title='Euro']";
        private string menuItemSelector = "#main-sidebar .item-wrapper:nth-child(2) > .item";
        private string demoSelector = ".demo-link:nth-child(1) a";
        private string addToCardSelector = "[data-product-name='One Step Checkout for Magento 2'] button";
        public string priceBoxSelector = ".big-price > div";
        private string newsletterSelector = "#newsletter";
        private string newsletterSuccessSelector = ".success-msg span";
        private string newsletterButtonSelector = "button[title='Subscribe']";
        private string newsletterSuccessText = "Thank you for your request. Please check your e-mail and confirm the subscription.";
        private string priorityServiceСheckboxSelector = "[name='priority_service_checkbox']";
        private string personalServiceСheckboxSelector = "[name='priority_service_checkbox']";
        private string EnterpriseEditionSelector = "[name='edition'][value='ee']";
        private string ProductNameSelector = ".item.product";
        private IWebDriver driver;

        public ProductPage()
        {
            this.driver = DriverSingleton.GetDriver();
        }

        public string getProductName()
        {
            return driver.FindElement(By.CssSelector(ProductNameSelector)).Text;            
        }

        public ProductPage clickEnterpriseEdition()
        {
            var EnterpriseEdition = driver.FindElement(By.CssSelector(EnterpriseEditionSelector));
            EnterpriseEdition.Click();

            return this;
        }
        public ProductPage clickServiceСheckbox()
        {
            var priorityServiceСheckbox = driver.FindElement(By.CssSelector(priorityServiceСheckboxSelector));
            priorityServiceСheckbox.Click();

            return this;
        }

        public bool isSelectPersonalServiceСheckbox()
        {
            var priorityServiceСheckbox = driver.FindElement(By.CssSelector(personalServiceСheckboxSelector));
            
            return priorityServiceСheckbox.GetAttribute("value") == "1";
        }

        public ProductPage Subscribe(User user)
        {
            var subscribe = driver.FindElement(By.CssSelector(newsletterSelector));
            subscribe.SendKeys(user.email);

            var subscribeButton = driver.FindElement(By.CssSelector(newsletterButtonSelector));
            subscribeButton.Click();
            

            return this;
        }


        public bool isSuccessSubscribe()
        {
            var subscribeSuccess = driver.FindElement(By.CssSelector(newsletterSuccessSelector));
            

            return subscribeSuccess.Text.IndexOf(newsletterSuccessText) >= 0;
        }


        public float getPriceProducts()
        {
            var productPrice = driver.FindElement(By.CssSelector(priceBoxSelector));
            var text = productPrice.Text;
            var price = Regex.Replace(text, @"\D+", "", RegexOptions.ECMAScript);
            return float.Parse(price); 
        }

        public void ChangeСurrency()
        {
            var currency = driver.FindElement(By.CssSelector(currencySelector));
            var url = currency.GetAttribute("href");
            driver.Navigate().GoToUrl(url);
        }

        public ProductPage addProduct(string name)
        {
            return this;
        }

        public bool isDemoEnable()
        {
            var demo = driver.FindElement(By.CssSelector(demoSelector));
            var url = demo.GetAttribute("href");
            return url.IndexOf("magento-demo.amasty.com") >= 0;
        }
    }
}
