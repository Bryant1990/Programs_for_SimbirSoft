using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace OpenAvitoWithSeleniumToFindCats
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithChrome();
        }

        static void WorkWithChrome ()
        {
            ChromeDriver Chrome;
            IWebElement UnivElem;
            //Chrome = new ChromeDriver(@"C:\Users\Компьютер\Downloads\chromedriver_win32");
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Navigate().GoToUrl("https://www.avito.ru/ulyanovsk");
            MainPage mainPage = new MainPage(Chrome);
            UnivElem = mainPage.FindPatsInPage();
            ClickThisElem(UnivElem);            
            Pats pats = new Pats(Chrome);
            UnivElem = pats.FindCatsInPage();
            ClickThisElem(UnivElem);            
            Cats cats = new Cats(Chrome);
            cats.MakeList();
            cats.FindCatWithMaxOrder();
            cats.ShowCats();                        
            Chrome.Quit();
            Console.ReadLine();
        }  
        static void ClickThisElem(IWebElement UnivElem) //Element Object
        {
            UnivElem.Click();
        }
    }
}
