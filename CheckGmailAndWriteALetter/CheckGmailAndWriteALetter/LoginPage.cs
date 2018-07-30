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
    class LoginPage
    {
        private ChromeDriver chrome;
        private By Login = By.Name("identifier");
        private string mail;

        public LoginPage(string mail, ChromeDriver chrome)
        {
            this.chrome = chrome;
            this.mail = mail;
        }
        public void EnterLogin()
        {
            chrome.FindElement(Login).SendKeys(mail);
            chrome.FindElement(Login).SendKeys(Keys.Enter);
        }

    }
}
