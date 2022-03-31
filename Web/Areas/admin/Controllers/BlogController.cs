using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogManager _blogManager;
        private readonly ICategoryManager _categoryManager;
        private readonly UserManager<K205User> _userManager;
        private readonly IWebHostEnvironment _environment;

        public BlogController(IBlogManager blogManager, ICategoryManager categoryManager, UserManager<K205User> userManager, IWebHostEnvironment environment)
        {
            _blogManager = blogManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: BlogController
        public IActionResult Index()
        {
            var blogs = _blogManager.GetAll();
            return View(blogs);
        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        public IActionResult Create()
        {
            
            ViewBag.Categories = _categoryManager.GetAll();
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog,IFormFile Image)
        {

            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }


            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                blog.SeoURL = "asdf";
                blog.PhotoURL = path;
                blog.K205UserId = userId;
                _blogManager.Create(blog);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
