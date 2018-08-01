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
    class PasswordPage
    {
        private ChromeDriver chrome;
        private By Password = By.Name("password");
        private string password;

        public PasswordPage(string password, ChromeDriver chrome)
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

