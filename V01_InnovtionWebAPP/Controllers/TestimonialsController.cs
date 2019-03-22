using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V01_InnovtionWebAPP.ActionMethod;
using V01_InnovtionWebAPP.Model;

namespace V01_InnovtionWebAPP.Controllers
{
    public class TestimonialsController : Controller
    {
        testimonialController _newInta =new testimonialController();
        // GET: Testimonials
        public ActionResult Index()
        {
           
            return View();
        }
        // GET: Testimonials Admin Dashboard
        public ActionResult Dashboard()
        {
            testimonialModel _is = new testimonialModel();
            _is.onHomePage = false;
            var result = _newInta.getUsersTestimonialsList(_is);
            return View(result);
        }
        // GET: Testimonials/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Testimonials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Testimonials/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Testimonials/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Testimonials/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Testimonials/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Testimonials/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
