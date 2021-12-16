
# Learning Selenium in C#

On this repos I want to learn QA Automation via Selenium in C#

## 🚀 About Me
I'm Rab Michael Bombeo a QA Engineer.

## Codes

### Using ChromeDriver, maximizing browser, and navigate to Url
```C#
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
```
### Search and EnterKeys
```C#
  IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);
```
### Framework

 - First, find on all list in the search(all selected item is in lowercase format)
 - Second, expected items are equal to actual items that in the search phase,
 - Thirds, if the expectItems and Acutal items are equals it should assert.

```C#
            IList<string> actualItems = driver.FindElements(By.CssSelector(".repo-list-item"))
                .Select(item => item.Text.ToLower())
                .ToList();

            IList<string> expectedItems = actualItems
                .Where(item => item.Contains(searchPhrase))
                .ToList();

            Assert.AreEqual(expectedItems, actualItems);
```

## Framework

 - [Nunit](https://nunit.org/)
 - [Linq](https://www.c-sharpcorner.com/UploadFile/72d20e/concept-of-linq-with-C-Sharp/)

## Languages

 - [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

