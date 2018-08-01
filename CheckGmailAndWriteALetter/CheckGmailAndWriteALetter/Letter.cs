using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace CheckGmailAndWriteALetter
{
    class Letter
    {
        private EdgeDriver chrome;
        private By ToPerson = By.Name("to");
        private By Subject = By.Name("subjectbox");
        private By Message = By.ClassName("Am");
        private By ButtonSent = By.CssSelector("td.gU.Up");
        private string MailToSentAMessage;
        private string subject;

        public Letter(string MailToSentAMessage, string subject, EdgeDriver chrome)
        {
            this.chrome = chrome;
            this.MailToSentAMessage = MailToSentAMessage;
            this.subject = subject;
        }

        public void ChooseAPersonToSent()
        {
            new WebDriverWait(chrome, TimeSpan.FromSeconds(20))
                .Until(chr => chrome.FindElement(ToPerson).Displayed);
            chrome.FindElement(ToPerson).SendKeys(MailToSentAMessage);
        }

        public void WriteASubject()
        {
            chrome.FindElement(Subject).SendKeys(subject);
        }

        public void WriteAMessage(string NumberOfLetters)
        {
            chrome.FindElement(Message).SendKeys("От Вас найдено писем: " + NumberOfLetters);
        }

        public void ClickToSentButton()
        {
            chrome.FindElement(ButtonSent).Click();
        }
    }
}
