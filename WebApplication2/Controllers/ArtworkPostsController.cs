using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SarahsArtworksBlog.Models;

namespace WebApplication2.Controllers
{
    public class ArtworkPostsController : Controller
    {
        private ArtworkBlogDbContext db = new ArtworkBlogDbContext();

        // GET: ArtworkPosts
        public ActionResult Index()
        {
            return View(db.ArtworkPosts.ToList());
        }

        // GET: ArtworkPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkPost artworkPost = db.ArtworkPosts.Find(id);
            if (artworkPost == null)
            {
                return HttpNotFound();
            }
            return View(artworkPost);
        }

        // GET: ArtworkPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtworkPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtworkPostID,date,text,image,Name")] ArtworkPost artworkPost)
        {
            if (ModelState.IsValid)
            {
                db.ArtworkPosts.Add(artworkPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artworkPost);
        }

        // GET: ArtworkPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkPost artworkPost = db.ArtworkPosts.Find(id);
            if (artworkPost == null)
            {
                return HttpNotFound();
            }
            return View(artworkPost);
        }

        // POST: ArtworkPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtworkPostID,date,text,image,Name")] ArtworkPost artworkPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artworkPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artworkPost);
        }

        // GET: ArtworkPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtworkPost artworkPost = db.ArtworkPosts.Find(id);
            if (artworkPost == null)
            {
                return HttpNotFound();
            }
            return View(artworkPost);
        }

        // POST: ArtworkPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtworkPost artworkPost = db.ArtworkPosts.Find(id);
            db.ArtworkPosts.Remove(artworkPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
