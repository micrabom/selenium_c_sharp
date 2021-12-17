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

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            string url = "https://amazon.com";
            string searchPhrase = "iphone";

            string url = "https://amazon.com";

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            IWebElement searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(items => items.Text.ToLower())
                .ToList();

            IList<string> expectedItems = actualItems
                .Where(items => items.Contains(searchPhrase))
                .ToList();

            Assert.True(actualItems.All(item => item.ToLower().Contains("invalid search pharase")));

            Thread.Sleep(25000);

            driver.Quit();
        }
    }
}
