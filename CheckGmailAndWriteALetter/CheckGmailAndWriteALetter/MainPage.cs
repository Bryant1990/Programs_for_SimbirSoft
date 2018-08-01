using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace CheckGmailAndWriteALetter
{
    class MainPage
    {
        private EdgeDriver chrome;
        private By Search = By.CssSelector("div.aoq");
        private By WriteALetter = By.CssSelector("div.T-I.J-J5-Ji.T-I-KE.L3");
        private By NumberOfLetters = By.CssSelector("span.ts");

        public MainPage(EdgeDriver chrome)
        {
            this.chrome = chrome;
        }

        public void ClickToSearch()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(30))
                .Until(chr => chrome.FindElement(Search).Displayed);
            chrome.FindElement(Search).Click();
        }

        public void ClickToWriteALetter()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(20))
                .Until(chr => chrome.FindElement(WriteALetter).Displayed);
            chrome.FindElement(WriteALetter).Click();
        }

        public string TakeANumberOfLetters()
        {
            string NumberOfLettersInString = chrome.FindElements(NumberOfLetters)[5].Text;
            return NumberOfLettersInString;
        }

    }
}
