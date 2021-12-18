
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SimpleApplicationRunner
{
    public class SeleniumApplicationRunner
    {
        //static IWebDriver driver = new ChromeDriver();
        static void Main()
        {
            string url = "https://github.com";
            string searchPhrase = "selenium";

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
                .Where(items => items.Contains(searchPhrase))
                .ToList();

            Assert.True(actualItems.All(item => item.ToLower().Contains("invalid search pharase")));

            Thread.Sleep(25000);

            driver.Quit();
        }
    }
}
