using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SarahsArtworksBlog.Models;

namespace SarahsArtworksBlog.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View(_context.ArtworkPosts.Take(1));
        }
        private ArtworkBlogDbContext _context;

        public HomeController()
        {
            _context = new ArtworkBlogDbContext();
        }
    }
}