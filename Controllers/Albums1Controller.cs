using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GA_DatabaseFirst.Data;
using GA_DatabaseFirst.Models;

namespace GA_DatabaseFirst.Controllers
{
    public class Albums1Controller : Controller
    {
        private GA_DatabaseFirstContext db = new GA_DatabaseFirstContext();

        // GET: Albums1
        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Artista);
            return View(albums.ToList());
        }

        // GET: Albums1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums1/Create
        public ActionResult Create()
        {
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ArtistaID", "NombrePilaArtista");
            return View();
        }

        // POST: Albums1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumID,NombreAlbum,AnioLanzamiento,NumCanciones,ArtistaID")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistaID = new SelectList(db.Artistas, "ArtistaID", "NombrePilaArtista", album.ArtistaID);
            return View(album);
        }

        // GET: Albums1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ArtistaID", "NombrePilaArtista", album.ArtistaID);
            return View(album);
        }

        // POST: Albums1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,NombreAlbum,AnioLanzamiento,NumCanciones,ArtistaID")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistaID = new SelectList(db.Artistas, "ArtistaID", "NombrePilaArtista", album.ArtistaID);
            return View(album);
        }

        // GET: Albums1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
