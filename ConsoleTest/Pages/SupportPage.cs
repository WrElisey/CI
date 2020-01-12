using Framework.Driver;
using OpenQA.Selenium;

namespace GitHubAutomation.Pages
{
    public class SupportPage
    {
        private IWebDriver driver; 
        private string menuItemSelector = "#main-sidebar .item-wrapper:nth-child(5) > .item";
        private string menuItemActiveSelector = "#main-sidebar .item-wrapper:nth-child(5) > .item.active";
        private string menuCategory = ".category-menu > .category";
        private string productsSelector = ".product-listing > .module";

        private string homeUrl = "https://amasty.com/";
        
        public SupportPage()
        {
            this.driver = DriverSingleton.GetDriver();
        }

        public int GetCountMenuCategory()
        {
            var menuItem = driver.FindElements(By.CssSelector(menuCategory));
            return menuItem.Count;
        }

        public bool IsMenuItemActive()
        {
            var menuItem = driver.FindElements(By.CssSelector(menuItemActiveSelector));
            return menuItem.Count > 0;
        }

        public int GetCountProducts()
        {
            var menuItem = driver.FindElements(By.CssSelector(productsSelector));
            return menuItem.Count;
        }

        public bool CheckExistAllElements()
        {
            return GetCountMenuCategory() > 0 && GetCountProducts() > 0 && IsMenuItemActive();
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(homeUrl);
        }
    }
}
