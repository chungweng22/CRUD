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
                clothes.CreatedDate = DateTime.Now;
                db.Clothes.Add(clothes);
                db.SaveChanges();
                return RedirectToAction("ReadAll");
            }

            return View(clothes);
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
