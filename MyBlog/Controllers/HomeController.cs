using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Domain;

namespace MyBlog
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
        public IActionResult About()
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageAbout"));
        }
        public IActionResult Listing()
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
        public IActionResult Post()
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
