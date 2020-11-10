using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Areas.Admin.Controllers
{
    [Route("fileupload")]
    public class CKEditorController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public CKEditorController(IWebHostEnvironment webHostEnvironment)
        {
            hostingEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }

        [Route("upload_ckeditor")]
        [HttpPost]
        public IActionResult UploadCKEditor(IFormFile upload)
        {
            ViewBag.isAut = HttpContext.User.Identity.IsAuthenticated;
            ViewBag.Name = HttpContext.User.Identity.Name;
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + upload.FileName;
            string path = Path.Combine(Directory.GetCurrentDirectory(), hostingEnvironment.WebRootPath, "img", filename);
            using var stream = new FileStream(path, FileMode.Create);
            upload.CopyTo(stream);
            return new JsonResult(new
            {
                uploaded = 1,
                fileName = filename,
                url = "/img/" + filename
            });
        }
    }
}
