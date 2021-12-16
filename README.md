
# Learning Selenium in C#

On this repos I want to learn QA Automation via Selenium in C#

## 🚀 About Me
I'm Rab Michael Bombeo a QA Engineer.

## Codes
Search and EnterKeys

```C#
  IWebElement searchInput = driver.FindElement(By.CssSelector("[name='q']"));
            searchInput.SendKeys(searchPhrase);
            searchInput.SendKeys(Keys.Enter);
```
Using ChromeDriver and maximizing browser
```C#
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
```


## Framework

 - [Nunit](https://nunit.org/)
 - [Linq](https://www.c-sharpcorner.com/UploadFile/72d20e/concept-of-linq-with-C-Sharp/)

## Languages

 - [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)

