using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AssertionHomeTask
{
    public class AssertionHomeTaskRunner
    {
      
        public static void Main()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            string url = "https://amazon.com";
            string searchPhrase = "iphone";

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            IWebElement searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);

            /*--- Find actualItems and know the actualItems ---*/

            var actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(items => items.Text.ToLower() + items.GetAttribute("href").ToLower())
                .ToList();

            var expectedItems = actualItems
                .Where(items => items.Contains("invalid search phrase"))
                .ToList();

            Assert.AreEqual(expectedItems, actualItems);

            Thread.Sleep(25000);

            driver.Quit();
        }
    }
}
