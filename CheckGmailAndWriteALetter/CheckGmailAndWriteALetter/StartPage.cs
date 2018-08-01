using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace CheckGmailAndWriteALetter
{
    class StartPage
    {
        private EdgeDriver chrome;
        private By SignIn = By.LinkText("Войти");

        public StartPage(EdgeDriver chrome)
        {
            this.chrome = chrome;
        }

        public void SignInLoginPage()
        {
            try
            {
                new WebDriverWait(chrome, TimeSpan.FromSeconds(30))
                    .Until(chr => chrome.FindElement(SignIn).Displayed);
                chrome.FindElement(SignIn).Click();
            }
            catch(Exception) { }
        }
    }
}
