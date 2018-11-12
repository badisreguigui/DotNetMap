using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MAPINFINITY2.Areas.admin2.Controllers
{
    public class DashboardController : Controller
    {
        // GET: admin2/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        // GET: admin2/Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: admin2/Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin2/Dashboard/Create
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

        // GET: admin2/Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: admin2/Dashboard/Edit/5
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

        // GET: admin2/Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: admin2/Dashboard/Delete/5
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
