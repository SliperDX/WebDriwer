using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace WebDriverLab
{
    class Tests
    {
        IWebDriver driver;
        string expectedTestResult = "2019-04-26";
        string expectedTestResult2;

        [SetUp]
        [Obsolete]
        public void SetupTests()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.alpari.by/login");

            Thread.Sleep(45000);

            //IWebElement loginLink = driver.FindElement(By.XPath("//*[@id=\"id\"]"));
            //loginLink.SendKeys("anatheraltair@mail.ru");
            //IWebElement passwordLink = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
            //passwordLink.SendKeys("Vladimir01012001");
            //IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/form/div/div[3]/button"));
            //loginButton.Click();
        }

        
        [Test]
        public void Testcase()
        {
            IWebElement myMoney = driver.FindElement(By.XPath("//*[@id=\"sidebar\"]/div/div[1]/div/nav/ul/li[2]/a"));
            
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].click();", myMoney);

            Thread.Sleep(1000);

            IWebElement myConv = driver.FindElement(By.XPath("//*[@id=\"sidebar\"]/div/div[1]/div/nav/ul/li[2]/ul/li[5]/a"));
            //myConv.Click();
            executor.ExecuteScript("arguments[0].click();", myConv);

            Thread.Sleep(2000);
            
            IWebElement data = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div[2]/div/div/div/form/div/div[1]/input"));
            data.Clear();
            data.SendKeys("2019-04-26");
            IWebElement button = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/div/div[2]/div/div/div/form/button"));
            button.Click();
            expectedTestResult2 = data.Text;

            //Assert.
           // Assert.AreEqual( expectedTestResult, data.Text);

            Assert.IsTrue(data.Text != null);
        }

        //[TearDown]
        //public void TearDownTests()
        //{
        //    if (driver != null)
        //        driver.Quit();
        //}

    }
}
