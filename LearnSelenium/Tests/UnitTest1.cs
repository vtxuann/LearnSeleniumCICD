using LearnSelenium.Extensions;
using LearnSelenium.Pages;

namespace LearnSelenium.Tests.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("https://www.google.com/");
            // 2a. Maximize the browser window
            driver.Manage().Window.Maximize();
            // 3. Find the element
            IWebElement webElement = driver.FindElement(By.Name("q"));
            // 4. Type in the element
            webElement.SendKeys("Selenium");
            // 5. Click on the element
            webElement.SendKeys(Keys.Return);

            webElement.Click();
        }

        [Test]
        public void EAWebsiteTest()
        {
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            // 3. Find the Login link
            var loginLink = driver.FindElement(By.Id("loginLink"));
            // 4. Click the Login link
            loginLink.Click();

            // 5. Explicit wait
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
                Message = "Textbox UserName does not appear during that timeframe"
            };

            driverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            var txtUserName = driverWait.Until(d =>
            {
                var element = driver.FindElement(By.Name("UserName"));
                return element != null && element.Displayed ? element : null;
            });

            // 6. Typing on the textUserName
            txtUserName.SendKeys("admin");
            // 7. Find the Password text box
            var txtPassword = driver.FindElement(By.Id("Password"));
            // 8. Typing on the textPassword
            txtPassword.SendKeys("password");
            // 9. Identify the Login Button using Class Name
            //IWebElement btnLogin = driver.FindElement(By.ClassName("btn"));
            // 9. Identify the Login Button using CssSelector
            var btnLogin = driver.FindElement(By.CssSelector(".btn"));
            // 10. Click login button
            btnLogin.Submit();
        }

        [Test]
        public void TestWithPOM()
        {
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();

            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            // POM initialization
            LoginPage loginPage = new LoginPage(driver);

            loginPage.ClickLogin();

            loginPage.Login("admin", "password");

        }

        [Test]
        public void EAWebSiteTestReduceSizeCode()
        {
            // 1. Create a new instance of Selenium Web Driver
            IWebDriver driver = new ChromeDriver();
            // 2. Navigate to the URL
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            // 3. Find and Click the Login link
            driver.FindElement(By.Id("loginLink")).Click();
            // 4. Find the UserName text box and typing on it
            driver.FindElement(By.Name("UserName")).SendKeys("admin");
            // 5. Find the Password text box and typing on it
            driver.FindElement(By.Id("Password")).SendKeys("password");
            // 6. Click submit button
            driver.FindElement(By.CssSelector(".btn")).Submit();
        }

        //[Test]
        //public void WorkingWithAdvanceControls()
        //{
        //    // 1. Create a new instance of Selenium Web Driver
        //    IWebDriver driver = new ChromeDriver();

        //    // 2. Navigate to the URL
        //    driver.Navigate().GoToUrl("file:///D:/testpage.html");

        //    SeleniumCustomMethods.SelectDropdownByText(driver, By.Id("dropdown"), "Option 2");

        //    SeleniumCustomMethods.MultiSelectElements(driver, By.Id("multiselect"), ["multi1", "multi2"]);

        //    var getSelectedOptions = SeleniumCustomMethods.GetAllSelectedList(driver, By.Id("multiselect"));
            
        //    getSelectedOptions.ForEach(Console.WriteLine);
        //}

        [Test]
        public void Test4()
        {

        }

        [Test]
        public void Test5()
        {

        }

    }
}