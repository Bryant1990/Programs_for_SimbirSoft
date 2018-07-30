using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using System.Collections.Generic;

namespace CheckGmailAndWriteALetter
{
    [TestClass]
    public class UnitTest1
    {
        ChromeDriver chrome;
        //List<IWebElement> NumberOfLettersInList;

        
        [TestMethod]
        public void TestMethod1()
        {
            //chrome = new ChromeDriver();
            chrome = new ChromeDriver(@"C:\Users\Компьютер\Downloads\chromedriver_win32");
            chrome.Manage().Window.Maximize();
            chrome.Navigate().GoToUrl("https://www.gmail.com");
            chrome.FindElement(By.Name("identifier")).SendKeys("msibgatullov@gmail.com");
            chrome.FindElement(By.Id("identifierId")).SendKeys(Keys.Enter);
            new WebDriverWait(chrome, TimeSpan.FromSeconds(20))
                .Until(chr => chrome.FindElement(By.Name("password")).Displayed);       
            chrome.FindElement(By.Name("password")).SendKeys("Lakers23");
            chrome.FindElement(By.Name("password")).SendKeys(Keys.Enter);
            try
            {
                new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
                    .Until(chr => chrome.FindElement(By.CssSelector("div.XHsn7e.dURtfb.Tk2jV")).Displayed);
                chrome.FindElement(By.CssSelector("div.XHsn7e.dURtfb.Tk2jV")).Click();
                chrome.FindElement(By.CssSelector("div.XHsn7e.dURtfb.Tk2jV")).Click();
                chrome.FindElement(By.CssSelector("div.XHsn7e.dURtfb.Tk2jV")).Click();
                new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
                    .Until(chr => chrome.FindElement(By.CssSelector("span.RveJvd.snByac")).Displayed);
                chrome.FindElement(By.CssSelector("span.RveJvd.snByac")).Click();                
            }
            catch (Exception)
            {

            }
            new WebDriverWait(chrome, TimeSpan.FromSeconds(30))
                .Until(chr => chrome.FindElement(By.CssSelector("div.aoq")).Displayed);
            chrome.FindElement(By.CssSelector("div.aoq")).Click();
            new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
                .Until(chr => chrome.FindElement(By.ClassName("ZH")).Displayed);
            chrome.FindElement(By.ClassName("ZH")).SendKeys("Бахтиярова");
            chrome.FindElement(By.ClassName("ZH")).SendKeys(Keys.Enter);
            new WebDriverWait(chrome, TimeSpan.FromSeconds(20))
                .Until(chr => chrome.FindElement(By.CssSelector("span.ts")).Displayed);
            
            //NumberOfLettersInList.AddRange(chrome.FindElements(By.CssSelector(".J-J5-Ji span.ts")));
            //string NumberOfLetters = NumberOfLettersInList[5].Text;
            //string NumberOfLetters = chrome.FindElement(By.ClassName("J-J5-Ji")).Text;            
            //Assert.Equals(Convert.ToInt32(NumberOfLetters), 12);
            chrome.FindElement(By.CssSelector("div.T-I.J-J5-Ji.T-I-KE.L3")).Click();
            new WebDriverWait(chrome, TimeSpan.FromSeconds(20))
                .Until(chr => chrome.FindElement(By.Name("to")).Displayed);
            chrome.FindElement(By.Name("to")).SendKeys("bryant1990@mail.ru");
            chrome.FindElement(By.Name("subjectbox")).SendKeys("Тестовое задание. Сибгатуллов");
            //chrome.FindElement(By.Name("subjectbox")).SendKeys(Keys.Tab);
            //chrome.FindElement(By.Name("subjectbox")).SendKeys("От Вас найдено" + NumberOfLetters + "писем");
            //chrome.FindElement(By.CssSelector("table.iN")).Click();
            //int NumberOfLetters = chrome.FindElements(By.CssSelector("span.ts")).Count;
            //int NumberOfLetters1 = chrome.FindElements(By.CssSelector("span.Dj")).Count;
            string NumberOfLetters = chrome.FindElements(By.CssSelector("span.ts"))[5].Text;
            //chrome.FindElement(By.ClassName("Am")).SendKeys("От Вас найдено " + NumberOfLetters + " писем");
            //chrome.FindElement(By.ClassName("Am")).SendKeys("\nОт Вас найдено " + NumberOfLetters1 + " писем");
            chrome.FindElement(By.ClassName("Am")).SendKeys("От Вас найдено писем: " + NumberOfLetters);
            chrome.FindElement(By.CssSelector("td.gU.Up")).Click();
            
        }        
        [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}
