using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Inventory.Models {
    public class Invnetory: Item {
        public virtual List<Category> Filter { get; set; }
        public bool IsWhiteList { get; set; }
        public virtual List<Item> Items { get; set; }  
    }
}
