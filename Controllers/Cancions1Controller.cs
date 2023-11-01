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
    public class Cancions1Controller : Controller
    {
        private GA_DatabaseFirstContext db = new GA_DatabaseFirstContext();

        // GET: Cancions1
        public ActionResult Index()
        {
            var cancions = db.Cancions.Include(c => c.Album);
            return View(cancions.ToList());
        }

        // GET: Cancions1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // GET: Cancions1/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "NombreAlbum");
            return View();
        }

        // POST: Cancions1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CancionID,NombreCancion,Duracion,AnioLanzamiento,Compositor,AlbumID")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Cancions.Add(cancion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "NombreAlbum", cancion.AlbumID);
            return View(cancion);
        }

        // GET: Cancions1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "NombreAlbum", cancion.AlbumID);
            return View(cancion);
        }

        // POST: Cancions1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CancionID,NombreCancion,Duracion,AnioLanzamiento,Compositor,AlbumID")] Cancion cancion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cancion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "AlbumID", "NombreAlbum", cancion.AlbumID);
            return View(cancion);
        }

        // GET: Cancions1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cancion cancion = db.Cancions.Find(id);
            if (cancion == null)
            {
                return HttpNotFound();
            }
            return View(cancion);
        }

        // POST: Cancions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cancion cancion = db.Cancions.Find(id);
            db.Cancions.Remove(cancion);
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
