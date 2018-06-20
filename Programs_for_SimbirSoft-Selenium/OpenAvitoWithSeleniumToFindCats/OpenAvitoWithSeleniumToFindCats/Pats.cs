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
    class Pats
    {
        ChromeDriver Chrome;        
        By RefCats = By.LinkText("Кошки");
        public Pats(ChromeDriver Chrome)
        {
            this.Chrome = Chrome;
        }
        public void ClickCats()
        {
            Chrome.FindElement(RefCats).Click();
        }
    }
}
