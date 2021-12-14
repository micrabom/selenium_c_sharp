
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumFirstProject
{
    public class SeleniumApplicationRunner
    {
        //static IWebDriver driver = new ChromeDriver();
        static void Main()
        {
            string url = "https://github.com";

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(url);

            IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys("selenium");
            searchInput.SendKeys(Keys.Enter);

            driver.Quit();
        }
    }
}
