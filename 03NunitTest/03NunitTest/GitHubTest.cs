using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace _03NunitTest
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetup]
        public static void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public  void CheckGitHubSearch()
        {
            string url = "https://github.com";
                        
            driver.Navigate().GoToUrl(url);

            IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys(SearchPhrase);
            searchInput.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(items => items.Text.ToLower())
                .ToList();
             
            IList<string> expectedItems = actualItems
                .Where(items => items.Contains("invalid Search Phrase"))
                .ToList();

            Assert.AreEqual(expectedItems, actualItems);

         /*   Thread.Sleep(3000);*/

            
        }
        [OneTimeTearDown]
        public static void TearDownDriver()
        {
            driver.Quit();
        }

    }
}
