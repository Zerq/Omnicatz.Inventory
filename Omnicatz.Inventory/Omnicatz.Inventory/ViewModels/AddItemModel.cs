using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Omnicatz.Inventory.ViewModels {
    public class AddItemModel {
        public Models.Item Item { get; set; }
        public HttpPostedFile Image { get; set; }
    }
}