using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Omnicatz.Inventory.Data;
 

namespace Omnicatz.Inventory.Controllers
{
    public class InventoryController : Controller
    {
        private Context db = new Context();

        // GET: Inventory
        public ActionResult Index()
        {
            return View(db.Inventories.ToList());
        }

        // GET: Inventory/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
          Models.Inventory invnetory = db.Inventories.Find(id.Value);
            if (invnetory == null)
            {
                return HttpNotFound();
            }
            return View(invnetory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NonExclusiveRef,Name,Description,IsWhiteList")] Models.Inventory invnetory)
        {
            if (ModelState.IsValid)
            {
 
                db.Inventories.Add(invnetory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invnetory);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Inventory invnetory = db.Inventories.Find(id);
            if (invnetory == null)
            {
                return HttpNotFound();
            }
            return View(invnetory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NonExclusiveRef,Name,Description,IsWhiteList")] Models.Inventory invnetory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invnetory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invnetory);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Inventory invnetory = db.Inventories.Find(id);
            if (invnetory == null)
            {
                return HttpNotFound();
            }
            return View(invnetory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Inventory invnetory = db.Inventories.Find(id);
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
