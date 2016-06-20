using Omnicatz.Inventory.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Omnicatz.Inventory.Controllers
{
    public class BarCodeController : Controller
    {
        private Context db = new Context();
        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public FileResult Index(int id)
        {
           // if (HttpContext.Request.Url.Host ==  "localhost") {
                var items = db.Items.ToArray();
                var item = db.Items.FirstOrDefault(n => n.Id == id);
                if (item == null) {
                    item = db.Inventories.FirstOrDefault(n => n.Id == id);
                }

                var writer = new ZXing.BarcodeWriter() { Format = ZXing.BarcodeFormat.CODE_39 };
                var bmp = writer.Write(item.NonExclusiveRef);
                byte[] bytes = null;
                using (System.IO.MemoryStream stream = new System.IO.MemoryStream()) {
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    bytes = stream.GetBuffer();
                }
                return File(bytes, @"image/png", "barcode.png");
           // }
         //   return new HttpUnauthorizedResult("Fuck of!");
        }
    }
}