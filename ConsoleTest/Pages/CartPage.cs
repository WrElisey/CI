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
    public class CartPage
    {
        private string productCartSelector = "#shopping-cart-table [title='<<NAME>>']";
        private static string pageUrl = "https://amasty.com/checkout/cart/";
        private IWebDriver driver;

        public CartPage()
        {
            this.driver = DriverSingleton.GetDriver();
        }

        public bool CheckProductIsCart(Product productObject)
        {
            string name = productObject.Name;
            var product = driver.FindElements(By.CssSelector(productCartSelector.Replace("<<NAME>>", name)));
           
            return product.Count > 0;
        }

        public static CartPage GoToPage()
        {
            DriverSingleton.GetDriver().Navigate().GoToUrl(pageUrl);
            return new CartPage();
        }

    }
}
