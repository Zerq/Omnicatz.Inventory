using System;
using System.Collections.Generic;

namespace PartyStarter.Models {
    public class Recipie {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }
        public virtual List<IngredientMessure> Ingredients { get; set; }       
    }
}