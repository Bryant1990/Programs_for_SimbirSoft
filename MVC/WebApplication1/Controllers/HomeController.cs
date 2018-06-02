using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Message2 = "Переопределение страницы About";
            ViewBag.Message3 = "Меня зовут Сибгатуллов Марат.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Message2 = "Переопределение страницы Contact";
            ViewBag.Message3 = "Мои контакты: 89276303014";
            return View();
        }

        [HttpGet]
        public ActionResult OurPage()
        {
            ViewBag.Message = "Your contact page.";
            Book book1 = new Book();
            book1.id = 1;
            book1.page_count = 100;
            book1.title = "Tom Sawer";
            Book book2 = new Book();
            book2.id = 2;
            book2.page_count = 200;
            book2.title = "The hero of our time";
            ViewBag.Message3 = book1.id.ToString() + " " + book1.title.ToString() + " " + book1.page_count.ToString();
            ViewBag.Message4 = book2.id.ToString() + " " + book2.title.ToString() + " " + book2.page_count.ToString();
            return View();
        }
        public ActionResult View2()
        {
            Book book1 = new Book();
            book1.id = 1;
            book1.page_count = 120;
            book1.title = "The little prince";
            Book book2 = new Book();
            book2.id = 2;
            book2.page_count = 140;
            book2.title = "Harry Potter";

            Book[] bookarray = new Book[] { book1, book2 };

            return View(bookarray);
        }
    }
}