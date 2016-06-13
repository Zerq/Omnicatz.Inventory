using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyStarter.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<EstimatedCostPerUnit> EstimatedCost {get;set;}
    }
}
