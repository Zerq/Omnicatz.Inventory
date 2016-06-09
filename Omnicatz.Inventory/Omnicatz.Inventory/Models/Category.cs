using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Inventory.Models {
   public class Category {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Children { get; set; }
        public virtual List<Item> AssosiatedItems { get; set; }
        public virtual List<Invnetory> AssosiatedFilters { get; set; }

        //system default 
        public static Category Container = new Category() { Id = new Guid("60e2da96-805c-4d63-bd0c-d2e9b27a05ad"), Name = "Container", Children = new List<Category>(), Parent = null };
    }
 
}
