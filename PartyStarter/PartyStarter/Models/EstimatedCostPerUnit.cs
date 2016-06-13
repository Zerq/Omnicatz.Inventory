using System;

namespace PartyStarter.Models {
    public class EstimatedCostPerUnit {
        public Guid Id { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual UnitPrefix UnitPrefix { get; set; }
        public decimal PricePerUnit { get; set; }
    }
}