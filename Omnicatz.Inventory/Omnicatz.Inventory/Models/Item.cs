using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Inventory.Models {
    public class Item {
  
        public Guid Id { get; set; }


        private string nonExclusiveRef;
        public string NonExclusiveRef { get {
                if (nonExclusiveRef == string.Empty) {
                    nonExclusiveRef = Id.ToString();
                }
                return nonExclusiveRef;
            } set {
                nonExclusiveRef = value;
            }
        } 


        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Category> Categories { get; set; } 
    }
}
