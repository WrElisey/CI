using System;
using System.IO;
using Framework.Driver;

using Framework.Services;
using GitHubAutomation.Tests;
using GitHubAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using Framework.Models;

namespace Framework.Tests
{
    class ShopTests : TestConfig
    {
        //10
        [Test]
        public void ChangeСurrency()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductsPage productsPage = HomePage.GoToPage().GoWithMenuToProductPage();
                float oldPrice = productsPage.getPriceProducts();
                productsPage.ChangeСurrency();
                float newPrice = productsPage.getPriceProducts();


                Assert.IsTrue(oldPrice != newPrice);
            });
        }

        //9
        [Test]
        public void CheckDemoProducts()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductPage productPage = HomePage.GoToPage().GoWithMenuToProductPage().GoToProduct(ProductCreator.WithName());
                Assert.IsTrue(productPage.isDemoEnable());
            });

        }

        //8
        [Test]
        public void Search()
        {
            MakeScreenshotWhenFail(() =>
            {
                string nameProduct = "Checkout";
                Assert.IsTrue(new HomePage().GoToPage().Search(nameProduct).isHighlightExist());
            });
        }


        //7
        [Test]
        public void ChangeCatOnProduct()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductsPage productsPage = HomePage.GoToPage().GoWithMenuToProductPage();
                
                Assert.IsTrue(productsPage.clickToCatMenu().IsMenuItemActive());
            });
        }

        //6
        [Test]
        public void checkNewsletterSubscribe()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductPage productPage = HomePage.GoToPage().GoWithMenuToProductPage().GoToProduct(ProductCreator.WithName());
                
                Assert.IsTrue(productPage.Subscribe(UserCreator.WithEmail()).isSuccessSubscribe());
            });
        }

        //5
        [Test]
        public void checkSupportMode()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductPage productPage = HomePage.GoToPage().GoWithMenuToProductPage().GoToProduct(ProductCreator.WithName());

                Assert.IsTrue(productPage.clickServiceСheckbox().isSelectPersonalServiceСheckbox());
            });
        }

        //4
        [Test]
        public void checkChangeEdition()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductPage productPage = HomePage.GoToPage().GoWithMenuToProductPage().GoToProduct(ProductCreator.WithName());
                float oldPrice = productPage.getPriceProducts();
                productPage.clickEnterpriseEdition();
                float newPrice = productPage.getPriceProducts();


                Assert.IsTrue(oldPrice != newPrice);
            });
        }

        //3
        [Test]
        public void checkProductPage()
        {
            MakeScreenshotWhenFail(() =>
            {
                Product product = ProductCreator.WithName();
                HomePage HomePage = new HomePage();
                ProductPage productPage = HomePage.GoToPage().GoWithMenuToProductPage().GoToProduct(product);
                Assert.IsTrue(productPage.getProductName() == product.Name);
            });
        }

        //2
        [Test]
        public void CheckAddProduct()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                ProductsPage productsPage = HomePage.GoToPage().GoWithMenuToProductPage();
                productsPage.AddProduct(ProductCreator.WithName())  ;
                CartPage cartPage = productsPage.GoToCartPage();
                Assert.IsTrue(cartPage.CheckProductIsCart(ProductCreator.WithName()));
            });
        }

        //1
        [Test]
        public void CheckSupportPage()
        {
            MakeScreenshotWhenFail(() =>
            {
                HomePage HomePage = new HomePage();
                var supportPage = HomePage.GoToPage().GoWithMenuToSupportPage();
                Assert.IsTrue(supportPage.IsMenuItemActive());
            });
        }
    }
}
