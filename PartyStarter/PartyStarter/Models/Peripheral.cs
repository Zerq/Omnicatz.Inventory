using System;

namespace PartyStarter.Models {
    public class Peripheral {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual MediaReader ParentHardware {get;set;}
    }
} 