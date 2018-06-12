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
            List<IWebElement> Cats, Orders;
            //Chrome = new ChromeDriver(@"C:\Users\Компьютер\Downloads\chromedriver_win32");
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Navigate().GoToUrl("https://www.avito.ru/ulyanovsk");
            Chrome.FindElement(By.LinkText("Животные")).Click();
            Chrome.FindElement(By.LinkText("Кошки")).Click();
            Cats = Chrome.FindElements(By.CssSelector("div.catalog-counts__row a")).ToList();
            Orders = Chrome.FindElements(By.CssSelector("div.catalog-counts__row span")).ToList();
            int maxIndexOrder = 0;
            int maxOrder = 0;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Convert.ToInt32(Orders[i].Text) > maxOrder)
                {
                    maxOrder = Convert.ToInt32(Orders[i].Text);
                    maxIndexOrder = i;
                }
            }
            Console.WriteLine("Больше всего предложений у породых кошек: {0}, у этой породы предложений: {1} ", Cats[maxIndexOrder].Text, maxOrder);
            string CatsMax = Chrome.FindElement(By.CssSelector("a.item-description-title-link")).Text;
            CatsFirstInSearch(CatsMax);            
            Chrome.Quit();
            Console.ReadLine();
        }
        static void CatsFirstInSearch(string CatsMax)
        {
            Console.WriteLine("Первая порода кошек в списке поиска: {0}", CatsMax);
        }
    }
}
