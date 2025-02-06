using blogWeb.Context;
using blogWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogWeb.Controllers
{
    public class AdminController : Controller
    {

        private readonly BlogDbContext _context;

        public AdminController(BlogDbContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            var blog=_context.Blogs.ToList();
            return View(blog);
        }
        public IActionResult EditBlog(int id)
        {
            var blog = _context.Blogs.Where(x=>x.Id==id).FirstOrDefault();  
            return View(blog);
        }
        public IActionResult DeleteBlog(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Blogs");
        }

        [HttpPost]
        public IActionResult EditBlog(Blog model)
        {
            var blog = _context.Blogs.Where(x => x.Id == model.Id).FirstOrDefault();
            blog.Name=model.Name;
            blog.Description=model.Description;
            blog.ImageUrl=model.ImageUrl;
            blog.Tags=model.Tags;
            blog.LikeCount=model.LikeCount;
            
            _context.SaveChanges();
           return  RedirectToAction("Blogs");
        }

        public IActionResult ToggleStatus(int id)
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            if(blog.Status==1)
            {
                blog.Status=0;
            }
            else
            {
                blog.Status = 1;
            }
            _context.SaveChanges();
            return RedirectToAction("Blogs");
        }

    }
}
