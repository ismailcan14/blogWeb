﻿using blogWeb.Context;
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
    }
}
