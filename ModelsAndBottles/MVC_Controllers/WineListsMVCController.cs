using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelsAndBottles.MVC_Controllers
{
    public class WineListsMVCController : Controller
    {
        // GET: WineListsMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: WineListsMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WineListsMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WineListsMVC/Create
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

        // GET: WineListsMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WineListsMVC/Edit/5
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

        // GET: WineListsMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WineListsMVC/Delete/5
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
