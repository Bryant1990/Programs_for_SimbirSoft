using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CheckGmailAndWriteALetter
{
    class SearchPage
    {
        private ChromeDriver chrome;
        private By FromPerson = By.ClassName("ZH");
        private string PersonToSearchALetterFrom;

        public SearchPage(string PersonToSearchALetterFrom, ChromeDriver chrome)
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
