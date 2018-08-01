using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace CheckGmailAndWriteALetter
{
    class SearchPage
    {
        private EdgeDriver chrome;
        private By FromPerson = By.ClassName("ZH");
        private string PersonToSearchALetterFrom;

        public SearchPage(string PersonToSearchALetterFrom, EdgeDriver chrome)
        {
            this.chrome = chrome;
            this.PersonToSearchALetterFrom = PersonToSearchALetterFrom;
        }

        public void SearchLettersFrom()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(10))
                .Until(chr => chrome.FindElement(FromPerson).Displayed);
            chrome.FindElement(FromPerson).SendKeys(PersonToSearchALetterFrom);
            chrome.FindElement(FromPerson).SendKeys(Keys.Enter);
        }
    }
}
