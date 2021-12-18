
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Threading;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SimpleAppTaskRunner
{
    public class SeleniumApplicationRunner
    {
        //static IWebDriver driver = new ChromeDriver();
        static void Main()
        {
            string url = "https://amazon.com";

            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl(url);

            IWebElement searchInput = driver.FindElement(By.CssSelector("#twotabsearchtextbox"));
            searchInput.SendKeys("iphone");
            searchInput.SendKeys(Keys.Enter);


            Thread.Sleep(30000);

            driver.Quit();
        }
    }
}
