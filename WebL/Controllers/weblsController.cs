using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebL.Models;

namespace WebL.Controllers
{
    public class weblsController : Controller
    {
        private WebLEntities db = new WebLEntities();

        public ActionResult Index()
        {
            return View(db.webls.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,address,phone")] webl webl)
        {
            if (ModelState.IsValid)
            {
                db.webls.Add(webl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(webl);
        }

        public JsonResult Delete(int EmployeeId)
        {
            bool result = false;
            webl webl = db.webls.Find(EmployeeId);
            if (webl != null)
            {
                db.webls.Remove(webl);
                db.SaveChanges();
                result = true;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult validateEmail(string email)
        {
            System.Threading.Thread.Sleep(500);
            var data = db.webls.Where(x => x.email == email).SingleOrDefault();

            if (data != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult validatePhone(string phone)
        {
            System.Threading.Thread.Sleep(500);
            var data = db.webls.Where(x => x.phone == phone).SingleOrDefault();

            if (data != null)
            {
                return Json(1);
            }
            else

            {
                return Json(0);
            }
        }

        // The rest are unuse scaffolding function
        // GET: webls/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    webl webl = db.webls.Find(id);
        //    if (webl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(webl);
        //}

        // GET: webls/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: webls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete([Bind(Include = "getterValue")] webl webl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.webls.Remove(webl);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(webl);
        //}

        // GET: webls/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    webl webl = db.webls.Find(id);
        //    if (webl == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(webl);
        //}

        // POST: webls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "id,name,email,address,phone")] webl webl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(webl).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(webl);
        //}

        // GET: webls/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //webl webl = db.webls.Find(id);
        //    //if (webl == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    //return View(webl);

        //    try
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        webl webl = db.webls.Find(id);
        //        if (webl != null)
        //        {
        //            db.webls.Remove(webl);
        //            db.SaveChanges();
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}

        // POST: webls/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    webl webl = db.webls.Find(id);
        //    db.webls.Remove(webl);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
