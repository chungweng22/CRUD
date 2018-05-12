using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class ClothesController : Controller
    {
        private ClothesEntities db = new ClothesEntities();

        // GET: Clothes
        public ActionResult ReadAll()
        {
            return View(db.Clothes.ToList());
        }

        // GET: Clothes/Details/5
        public ActionResult Read()
        {
            return View(); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Read(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View("Read2",clothes);
        }

        // GET: Clothes/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                clothes.ModifiedDate = DateTime.Now;
                db.Clothes.Add(clothes);
                db.SaveChanges();
                return RedirectToAction("ReadAll");
            }

            return View(clothes);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothes).State = EntityState.Modified;
                clothes.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("ReadAll");
            }
            return View(clothes);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothes clothes = db.Clothes.Find(id);
            if (clothes == null)
            {
                return HttpNotFound();
            }
            return View(clothes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothes clothes = db.Clothes.Find(id);
            db.Clothes.Remove(clothes);
            db.SaveChanges();
            return RedirectToAction("ReadAll");
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
