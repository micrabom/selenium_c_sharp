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

namespace ImplicitsWait
{
    public class GitHubTest
    {
        private const string SearchPhrase = "selenium";

        private static IWebDriver driver;

        [OneTimeSetUp]
        public static void SetUpDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void CheckGitHubSearch()
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
                .Where(items => items.Contains(SearchPhrase))
                .ToList();

            Console.WriteLine(DateTime.Now.ToLongTimeString());

            Assert.True(IsElementVisible(By.CssSelector(SearchPhrase)));

            //Assert.AreEqual(expectedItems, actualItems);

            /*   Thread.Sleep(3000);*/

        }

        [OneTimeTearDown]
        public static void TearDownDriver()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            driver.Quit();
        }

        private bool IsElementVisible(By selector)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            try
            {
                return driver.FindElement(selector).Displayed;

            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                Console.WriteLine(DateTime.Now.ToLongTimeString());
            }
}   }   }
