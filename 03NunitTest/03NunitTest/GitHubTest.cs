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

        [Test]
        public  void CheckGitHubSearch()
        {
            string url = "https://github.com";
            

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(url);

            IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys("selenium");
            searchInput.SendKeys(Keys.Enter);

            IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(items => items.Text.ToLower())
                .ToList();

            IList<string> expectedItems = actualItems
                .Where(items => items.Contains(SearchPhrase))
                .ToList();

            Assert.True(actualItems.All(item => item.ToLower().Contains("invalid search pharase")));

            Thread.Sleep(5000);

            driver.Quit();
        }
    }
}
