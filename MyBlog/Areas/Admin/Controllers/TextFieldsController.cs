﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.Domain;
using MyBlog.Domain.Entities;
using MyBlog.Service;

namespace MyBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
