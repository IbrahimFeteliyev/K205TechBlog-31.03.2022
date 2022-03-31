using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BlogController : Controller

    {
        private readonly IBlogManager _blogManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<K205User> _userManager;
        private readonly ICommentManager _commentmanager;

        public BlogController(IBlogManager blogManager, IHttpContextAccessor httpContextAccessor, UserManager<K205User> usermanager, ICommentManager commentmanager)
        {
            _blogManager = blogManager;
            _httpContextAccessor = httpContextAccessor;
            _userManager = usermanager;
            _commentmanager = commentmanager;
        }

        public IActionResult Detail(int? id)
        {
            var blog = _blogManager.GetById(id);
           var selectedUser= _userManager.FindByIdAsync(blog.K205UserId);
            BlogSingleVM vm = new()
            {
                BlogSingle = blog,
                User = selectedUser.Result,
                Similar = _blogManager.Similar(blog.CategoryID,blog.K205UserId, blog.ID),
                Comments = _commentmanager.GetBlogComment(blog.ID),
            };
            return View(vm);
        }
    }
}
