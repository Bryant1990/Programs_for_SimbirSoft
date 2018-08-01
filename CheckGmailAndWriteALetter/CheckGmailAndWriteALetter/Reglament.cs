using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace CheckGmailAndWriteALetter
{
    class Reglament
    {
        private EdgeDriver chrome;
        private By ArrowDown = By.CssSelector("div.XHsn7e.dURtfb.Tk2jV");
        private By ButtonAccept = By.CssSelector("span.RveJvd.snByac");

        public Reglament(EdgeDriver chrome)
        {
            this.chrome = chrome;
        }

        public void ClickToArrowDown()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
                .Until(chr => chrome.FindElement(ArrowDown).Displayed);
            chrome.FindElement(ArrowDown).Click();
        }

        public void ClickToAcceptButton()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
                .Until(chr => chrome.FindElement(ButtonAccept).Displayed);
            chrome.FindElement(ButtonAccept).Click();
        }
    }
}
