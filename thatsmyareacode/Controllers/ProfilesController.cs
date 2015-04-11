using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using thatsmyareacode.Models;

namespace thatsmyareacode.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profiles
        public ActionResult Index()
        {
            return View(db.Profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profiles profiles = db.Profiles.Find(id);
            if (profiles == null)
            {
                return HttpNotFound();
            }
            return View(profiles);
        }

        // GET: Profiles/Create
        [Authorize(Roles = "canEdit")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Create([Bind(Include = "ProfileId,Name,Address,City,State,Zip,AreaCode,Email")] Profiles profiles)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profiles);
        }

        // GET: Profiles/Edit/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profiles profiles = db.Profiles.Find(id);
            if (profiles == null)
            {
                return HttpNotFound();
            }
            return View(profiles);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult Edit([Bind(Include = "ProfileId,Name,Address,City,State,Zip,AreaCode,Email")] Profiles profiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profiles);
        }

        // GET: Profiles/Delete/5
        [Authorize(Roles = "canEdit")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profiles profiles = db.Profiles.Find(id);
            if (profiles == null)
            {
                return HttpNotFound();
            }
            return View(profiles);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit")]
        public ActionResult DeleteConfirmed(int id)
        {
            Profiles profiles = db.Profiles.Find(id);
            db.Profiles.Remove(profiles);
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
