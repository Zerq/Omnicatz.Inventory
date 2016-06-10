using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Inventory.Models {
   public class Category {
        public Category() {
            this.Children = new List<Category>();
            this.AssosiatedFilters = new List<Inventory>();
            this.AssosiatedItems = new List<Item>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Children { get; set; }
        public virtual List<Item> AssosiatedItems { get; set; }
        public virtual List<Inventory> AssosiatedFilters { get; set; }

        //system default 
        public static Category Container = new Category() { Id = 0, Name = "Container", Children = new List<Category>(), Parent = null };
    }
 
}
