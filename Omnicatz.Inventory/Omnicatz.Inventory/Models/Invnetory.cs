using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Inventory.Models {
    public class Inventory: Item {
        public Inventory() {
            this.Items = new List<Item>();
            this.Categories = new List<Category>();
        }

        public virtual List<Category> Filter { get; set; }
        public bool IsWhiteList { get; set; }
        public ContainerClass Class { get; set; }
        public virtual List<Item> Items { get; set; }


        public override string NonExclusiveRef {
            get {
                if (nonExclusiveRef == string.Empty) {
                    switch (this.Class) {
                        case ContainerClass.LongTerm:
                            nonExclusiveRef = "L" + Id.ToString();
                            break;
                        case ContainerClass.Normal:
                            nonExclusiveRef = "N" + Id.ToString();
                            break;
                        case ContainerClass.WorkingContainer:
                            nonExclusiveRef = "W" + Id.ToString();
                            break;
                        default:
                            break;
                    }                 
                }
                return nonExclusiveRef;
            }
            set {
                nonExclusiveRef = value;
            }
        }
    }
}

namespace Omnicatz.Inventory.Models {
   public enum ContainerClass {
        LongTerm,
        Normal,
        WorkingContainer
    }
}