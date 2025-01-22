using blogWeb.Context;
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
            return View(blog);
        }
    }
}
