using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace CheckGmailAndWriteALetter
{
    class PasswordPage
    {
        private EdgeDriver chrome;
        private By Password = By.Name("password");
        private string password;

        public PasswordPage(string password, EdgeDriver chrome)
        {
            this.chrome = chrome;
            this.password = password;
        }
        public void EnterPassword()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(20))
                .Until(chr => chrome.FindElement(Password).Displayed);
            chrome.FindElement(Password).SendKeys(password);
            chrome.FindElement(Password).SendKeys(Keys.Enter);
        }
    }
}

