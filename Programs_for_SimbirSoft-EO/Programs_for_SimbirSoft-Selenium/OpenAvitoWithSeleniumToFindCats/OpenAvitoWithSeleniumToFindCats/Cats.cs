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
    class Cats
    {
        ChromeDriver Chrome;
        By ListCats = By.CssSelector("div.catalog-counts__row a");
        By ListOrders = By.CssSelector("div.catalog-counts__row span");
        By RefFirstCatInSearch = By.CssSelector("a.item-description-title-link");
        List<IWebElement> Cat, Orders;
        int maxIndexOrder;
        int maxOrder;        
        public Cats(ChromeDriver Chrome)
        {
            this.Chrome = Chrome;
        }
        public void MakeList()
        {
            Cat = Chrome.FindElements(ListCats).ToList();
            Orders = Chrome.FindElements(ListOrders).ToList();
        }
        public void FindCatWithMaxOrder()
        {
            maxIndexOrder = 0;
            maxOrder = 0;
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Convert.ToInt32(Orders[i].Text) > maxOrder)
                {
                    maxOrder = Convert.ToInt32(Orders[i].Text);
                    maxIndexOrder = i;
                }
            }
        }
        public void ShowCats()
        {        
            
            Console.WriteLine("Больше всего предложений у породых кошек: {0}, у этой породы предложений: {1} ", Cat[maxIndexOrder].Text, maxOrder);
            string CatsMax = Chrome.FindElement(RefFirstCatInSearch).Text;
            Console.WriteLine("Первая порода кошек в списке поиска: {0}", CatsMax);            
        }        
    }
}
