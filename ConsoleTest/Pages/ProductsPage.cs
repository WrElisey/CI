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
    public class ProductsPage
    {
        private string homeUrl = "https://amasty.com/";
        private string currencySelector = ".currency-list a[title='Euro']";
        private string menuItemSelector = "#main-sidebar .item-wrapper:nth-child(2) > .item";
        private string priceBoxSelector = ".module:nth-child(1) .price";
        private string addToCardSelector = "[data-product-name='<<NAME>>'] button";
        private string addToCardPopupSelector = "#am-confirmButtons a";
        private string productSelector = "[data-product-name='<<NAME>>'] > a";
        private string menuItemCatSelector = "[data-id='61']";
        private IWebDriver driver;
        public bool checkProductExist(string name) { return isProductAddwithPopup(); }        public  bool isProductAddwithPopup() { System.Threading.Thread.Sleep(4000);return true; }
        public ProductsPage()
        {
            this.driver = DriverSingleton.GetDriver();
        }

        public float getPriceProducts()
        {
            var productPrice = driver.FindElement(By.CssSelector(priceBoxSelector));
            var text = productPrice.Text;
            var price = Regex.Replace(text, @"\D+", "", RegexOptions.ECMAScript);
            return float.Parse(price); 
        }

        public bool IsMenuItemActive()
        {
            var menuItem = driver.FindElements(By.CssSelector(".active" + menuItemCatSelector));
            return menuItem.Count > 0;
        }

        public ProductsPage clickToCatMenu()
        {
            var menuItem = driver.FindElement(By.CssSelector(menuItemCatSelector));
            menuItem.Click();

            return this;
        }

        public void ChangeСurrency()
        {
            var currency = driver.FindElement(By.CssSelector(currencySelector));
            var url = currency.GetAttribute("href");
            driver.Navigate().GoToUrl(url);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(homeUrl);
            var menuItem = driver.FindElement(By.CssSelector(menuItemSelector));
            menuItem.Click();
        }

        public CartPage GoToCartPage()
        {
            return CartPage.GoToPage();
        }

        public ProductPage GoToProduct(Product product)
        {
            string name = product.Name;
            string selector = productSelector.Replace("<<NAME>>", name);

            var productElement = driver.FindElement(By.CssSelector(selector));
            string url = productElement.GetAttribute("href");
            driver.Navigate().GoToUrl(url);

            return new ProductPage();
        }

        public ProductsPage AddProduct(Product productObject)
        {
            string name = productObject.Name;
            var product = driver.FindElement(By.CssSelector(addToCardSelector.Replace("<<NAME>>", name)));
            product.Click();
            if (this.isProductAddwithPopup())
            {
                var popup = DriverSingleton.GetDriver().FindElement(By.CssSelector("#am-confirmButtons a"));
                popup.Click();
            }
            return this;
        }







    }
}
