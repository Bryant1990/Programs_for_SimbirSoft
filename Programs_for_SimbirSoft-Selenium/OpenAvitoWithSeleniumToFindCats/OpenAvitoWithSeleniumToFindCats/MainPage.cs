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
    class MainPage
    {
        ChromeDriver Chrome;
        By RefPats = By.LinkText("Животные");        
        public MainPage(ChromeDriver Chrome)
        {
            this.Chrome = Chrome;
        }
        public IWebElement FindPatsInPage()
        {
            IWebElement RefPatsToClick = Chrome.FindElement(RefPats);
            return RefPatsToClick;            
        }
    }
}
