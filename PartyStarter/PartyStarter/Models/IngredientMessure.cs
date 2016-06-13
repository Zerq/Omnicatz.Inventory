using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyStarter.Models
{
    public class IngredientMessure
    {
        public Guid Id { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual UnitPrefix Prefix { get; set; }
        public virtual Unit Unit { get; set; }
        public int Ammount { get; set; }
    }
}
