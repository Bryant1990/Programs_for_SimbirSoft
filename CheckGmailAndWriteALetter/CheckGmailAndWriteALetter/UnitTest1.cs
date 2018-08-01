using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace CheckGmailAndWriteALetter
{
    [TestClass]
    public class UnitTest
    {        
        ChromeDriver chrome = new ChromeDriver();
        //ChromeDriver chrome = new ChromeDriver(@"C:\Users\Компьютер\Downloads\chromedriver_win32");
        string URL = "https://www.gmail.com";
        string mail = "msibgatullov@gmail.com";
        string password = "Lakers23";
        string PersonToSearchALetterFrom = "Филинин Илья";
        string MailToSentAMessage = "ilya.filinin@simbirsoft.com";
        string subject = "Тестовое задание. Сибгатуллов";
        
        [TestMethod]
        public void UnitTestMethod()
        {            
            chrome.Manage().Window.Maximize();
            chrome.Navigate().GoToUrl(URL);
            LoginPage LP = new LoginPage(mail, chrome);
            LP.EnterLogin();
            PasswordPage PP = new PasswordPage(password, chrome);
            PP.EnterPassword();
            try
            {
                Reglament ment = new Reglament(chrome);
                for (int i = 0; i < 3; i++)
                {
                    ment.ClickToArrowDown();
                }
                ment.ClickToAcceptButton();
            }
            catch (Exception)
            { }
            MainPage MP = new MainPage(chrome);
            MP.ClickToSearch();
            SearchPage SP = new SearchPage(PersonToSearchALetterFrom, chrome);
            SP.SearchLettersFrom();            
            MP.ClickToWriteALetter();
            Letter Let = new Letter(MailToSentAMessage, subject, chrome);
            Let.ChooseAPersonToSent();
            Let.WriteASubject();            
            Let.WriteAMessage(MP.TakeANumberOfLetters());
            Let.ClickToSentButton();
        }       

        [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}
