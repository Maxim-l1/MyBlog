using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Domain;

namespace MyBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly DataManager dataManager;

        public PostsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            if (id != default)
            {
                return View("Show", dataManager.PostItems.GetPostItemById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageIndex");
            return View(dataManager.PostItems.GetPostItems());
        }
    }
}
