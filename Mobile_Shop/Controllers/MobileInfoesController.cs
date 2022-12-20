using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mobile_Shop.Models;

namespace Mobile_Shop.Controllers
{
    public class MobileInfoesController : Controller
    {
        private MobileShopEntities db = new MobileShopEntities();

        // GET: MobileInfoes
        public ActionResult Index()
        {
            return View(db.MobileInfoes.ToList());
        }

        // GET: MobileInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            if (mobileInfo == null)
            {
                return HttpNotFound();
            }
            return View(mobileInfo);
        }

        // GET: MobileInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MobileInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelNo,Brand,Weight,Resolution,DisplayType,OS,Chipset,RAM,Storage,MainCamera")] MobileInfo mobileInfo)
        {
            if (ModelState.IsValid)
            {
                db.MobileInfoes.Add(mobileInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mobileInfo);
        }

        // GET: MobileInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            if (mobileInfo == null)
            {
                return HttpNotFound();
            }
            return View(mobileInfo);
        }

        // POST: MobileInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelNo,Brand,Weight,Resolution,DisplayType,OS,Chipset,RAM,Storage,MainCamera")] MobileInfo mobileInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mobileInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mobileInfo);
        }

        // GET: MobileInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            if (mobileInfo == null)
            {
                return HttpNotFound();
            }
            return View(mobileInfo);
        }

        // POST: MobileInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MobileInfo mobileInfo = db.MobileInfoes.Find(id);
            db.MobileInfoes.Remove(mobileInfo);
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
