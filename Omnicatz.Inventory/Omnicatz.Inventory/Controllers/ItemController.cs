using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Omnicatz.Inventory.Data;
using Omnicatz.Inventory.Models;
using DYMO.Label.Framework;

namespace Omnicatz.Inventory.Controllers
{
    public class ItemController : Controller
    {
        private Context db = new Context();

        // GET: Items
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Image", Exclude = "NonExclusiveRef")] ViewModels.AddItemModel item)
        {
           
            if (ModelState.IsValid)
            { 
                db.Items.Add(item.Item);
                db.SaveChanges();

                var inventory = item.Item as Inventory.Models.Inventory;

                if (item.Image != null) {
                    item.Item.NonExclusiveRef = ToImage(item.Image);
                }


                return RedirectToAction("Print",item.Item.Id); // <-- change this i want a result view where you can print a barcode and the preview is  displayed using zxing
            }

            return View(item);
        }



        public ActionResult Print(Guid? id, bool Print=false) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null) {
                return HttpNotFound();
            }

            if (Print) {
                //<input type="file" accept="image/*" capture="camera"> <--- Awesome!
                Printers x = new Printers();
                var printer = x.First();
                ILabel label = Label.Open("barcode.label");
                label.SetObjectText("BARCODE", item.NonExclusiveRef);
                label.Print(printer);
                return RedirectToAction("Index"); // printed
            } else {
                return View(item);
            }

 
        }





        private string ToImage(HttpPostedFile file) {
            var reader = new ZXing.BarcodeReader();
            return reader.Decode(new Bitmap(System.Drawing.Image.FromStream(file.InputStream))).Text;         
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NonExclusiveRef,Name,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
