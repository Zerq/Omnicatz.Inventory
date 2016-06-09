using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Omnicatz.Inventory.Data;
using Omnicatz.Inventory.Models;

namespace Omnicatz.Inventory.Controllers
{
    public class InvnetoriesController : Controller
    {
        private Context db = new Context();

        // GET: Invnetories
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: Invnetories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invnetory invnetory = db.Inventories.Find(id.Value);
            if (invnetory == null)
            {
                return HttpNotFound();
            }
            return View(invnetory);
        }

        // GET: Invnetories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Invnetories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NonExclusiveRef,Name,Description,IsWhiteList")] Invnetory invnetory)
        {
            if (ModelState.IsValid)
            {
                invnetory.Id = Guid.NewGuid();
                db.Items.Add(invnetory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invnetory);
        }

        // GET: Invnetories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invnetory invnetory = db.Inventories.Find(id);
            if (invnetory == null)
            {
                return HttpNotFound();
            }
            return View(invnetory);
        }

        // POST: Invnetories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NonExclusiveRef,Name,Description,IsWhiteList")] Invnetory invnetory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invnetory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invnetory);
        }

        // GET: Invnetories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invnetory invnetory = db.Inventories.Find(id);
            if (invnetory == null)
            {
                return HttpNotFound();
            }
            return View(invnetory);
        }

        // POST: Invnetories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Invnetory invnetory = db.Inventories.Find(id);
            db.Items.Remove(invnetory);
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
