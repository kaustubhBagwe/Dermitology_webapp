using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using V01_InnovtionWebAPP.DBContext;
using V01_InnovtionWebAPP.Models;

namespace V01_InnovtionWebAPP.Controllers
{
    public class ServiceSubCtegoriesController : Controller
    {
        private innovationDbContext db = new innovationDbContext();

        // GET: ServiceSubCtegories
        public ActionResult Index()
        {
            var serviceSubCtegories = db.ServiceSubCtegories.Include(s => s.FK_Category);
            return View(serviceSubCtegories.ToList());
        }

        // GET: ServiceSubCtegories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSubCtegory serviceSubCtegory = db.ServiceSubCtegories.Find(id);
            if (serviceSubCtegory == null)
            {
                return HttpNotFound();
            }
            return View(serviceSubCtegory);
        }

        // GET: ServiceSubCtegories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ServiceCategories, "ServiceCategory_ID", "Name");
            return View();
        }

        // POST: ServiceSubCtegories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceSubCategoryID,CategoryID,SubCategoryName,SubCategoryDescrption,Isctive,SEOMeta,SEOTitle,CreatedDate,LMD")] ServiceSubCtegory serviceSubCtegory)
        {
            if (ModelState.IsValid)
            {
                db.ServiceSubCtegories.Add(serviceSubCtegory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.ServiceCategories, "ServiceCategory_ID", "Name", serviceSubCtegory.CategoryID);
            return View(serviceSubCtegory);
        }

        // GET: ServiceSubCtegories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSubCtegory serviceSubCtegory = db.ServiceSubCtegories.Find(id);
            if (serviceSubCtegory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ServiceCategories, "ServiceCategory_ID", "Name", serviceSubCtegory.CategoryID);
            return View(serviceSubCtegory);
        }

        // POST: ServiceSubCtegories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceSubCategoryID,CategoryID,SubCategoryName,SubCategoryDescrption,Isctive,SEOMeta,SEOTitle,CreatedDate,LMD")] ServiceSubCtegory serviceSubCtegory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceSubCtegory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.ServiceCategories, "ServiceCategory_ID", "Name", serviceSubCtegory.CategoryID);
            return View(serviceSubCtegory);
        }

        // GET: ServiceSubCtegories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSubCtegory serviceSubCtegory = db.ServiceSubCtegories.Find(id);
            if (serviceSubCtegory == null)
            {
                return HttpNotFound();
            }
            return View(serviceSubCtegory);
        }

        // POST: ServiceSubCtegories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceSubCtegory serviceSubCtegory = db.ServiceSubCtegories.Find(id);
            db.ServiceSubCtegories.Remove(serviceSubCtegory);
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
