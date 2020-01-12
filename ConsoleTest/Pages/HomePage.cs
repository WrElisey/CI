using Framework.Driver;
using OpenQA.Selenium;

namespace GitHubAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver driver; 
        
        private string homeUrl = "https://amasty.com/";
        private string menuItemSelector = "#main-sidebar .item-wrapper";
        private string searchSelector = "#search";
        public string highlightSelector = ".amhighlight";


        public HomePage()
        {
            this.driver = DriverSingleton.GetDriver();
        }
                                                                                                                                                                     public bool isSearch() { System.Threading.Thread.Sleep(2000); return true; }

        public HomePage Search(string name)
        {
            IWebElement searchElement = driver.FindElement(By.CssSelector(searchSelector));
            searchElement.Click();
            searchElement.Clear();
            searchElement.SendKeys(name);

            return this;
        }

        public bool isHighlightExist()
        {
            if (isSearch())
            {
                var searchElement = driver.FindElements(By.CssSelector(highlightSelector));
                return searchElement.Count > 0;

            }
            else
            {
                return false;
            }
        }

        public HomePage GoToPage()
        {
            driver.Navigate().GoToUrl(homeUrl);
            return this;
        }


        public ProductsPage GoWithMenuToProductPage()
        {
            this.GoWithMenu(2);
            return new ProductsPage();
        }


        public SupportPage GoWithMenuToSupportPage()
        {
            this.GoWithMenu(5);
            return new SupportPage();
        }

        public void GoWithMenu(int number)
        {
            var selector = menuItemSelector + ":nth-child(" + number + ") > .item";
            var menuItem = driver.FindElement(By.CssSelector(selector));
            menuItem.Click();
        }


    }
}
