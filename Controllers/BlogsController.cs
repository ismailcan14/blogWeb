using blogWeb.Context;
using blogWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogWeb.Controllers
{


    public class BlogsController : Controller
    {
        private readonly BlogDbContext _context;
        public BlogsController(BlogDbContext context) {  _context = context; }
        public IActionResult Index()
        {
            //var blogs=_context.Blogs.ToList();
            var blogs =_context.Blogs.Where(x=>x.Status==1).ToList();
            return View(blogs);
        }

        public IActionResult Details(int id) 
        {
            var blog = _context.Blogs.Where(x => x.Id == id).FirstOrDefault();
            var comment = _context.Comments.Where(x => x.BlogId == id).ToList();
            ViewBag.Comments=comment.ToList();
            return View(blog);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment model)
        {
            model.PublishDate = DateTime.Now;
            _context.Comments.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Details", new {id=model.BlogId});
        }
    }
}
