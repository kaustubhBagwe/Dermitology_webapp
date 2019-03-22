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
    public class ServiceCategoriesController : Controller
    {
        private innovationDbContext db = new innovationDbContext();

        // GET: ServiceCategories
        public ActionResult Index()
        {
            return View(db.ServiceCategories.ToList());
        }

        // GET: ServiceCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCategory serviceCategory = db.ServiceCategories.Find(id);
            if (serviceCategory == null)
            {
                return HttpNotFound();
            }
            return View(serviceCategory);
        }

        // GET: ServiceCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                serviceCategory.createdDate = DateTime.Now;
                serviceCategory.LMD = DateTime.Now;
                db.ServiceCategories.Add(serviceCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceCategory);
        }

        // GET: ServiceCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCategory serviceCategory = db.ServiceCategories.Find(id);
            if (serviceCategory == null)
            {
                return HttpNotFound();
            }
            return View(serviceCategory);
        }

        // POST: ServiceCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceCategory_ID,Name,Description,IsActive,SEO_Title,SEO_Meta,createdDate,LMD")] ServiceCategory serviceCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceCategory);
        }

        // GET: ServiceCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceCategory serviceCategory = db.ServiceCategories.Find(id);
            if (serviceCategory == null)
            {
                return HttpNotFound();
            }
            return View(serviceCategory);
        }

        // POST: ServiceCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceCategory serviceCategory = db.ServiceCategories.Find(id);
            db.ServiceCategories.Remove(serviceCategory);
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
