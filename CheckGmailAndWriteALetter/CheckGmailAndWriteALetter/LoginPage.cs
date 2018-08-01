using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace CheckGmailAndWriteALetter
{
    class LoginPage
    {
        private EdgeDriver chrome;
        private By Login = By.Name("identifier");
        private string mail;

        public LoginPage(string mail, EdgeDriver chrome)
        {
            this.chrome = chrome;
            this.mail = mail;
        }
        public void EnterLogin()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(30))
                .Until(chr => chrome.FindElement(Login).Displayed);
            chrome.FindElement(Login).SendKeys(mail);
            chrome.FindElement(Login).SendKeys(Keys.Enter);
        }

    }
}
