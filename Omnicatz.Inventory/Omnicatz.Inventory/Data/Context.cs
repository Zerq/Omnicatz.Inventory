using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnicatz.Inventory.Data {
   public class Context: System.Data.Entity.DbContext {
        public Context() : base("DefaultConnection") {}
 
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Item> Items { get; set; }
        public DbSet<Models.Inventory> Inventories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Models.Category>().HasKey(n => n.Id);
            modelBuilder.Entity<Models.Category>().HasMany(n => n.AssosiatedFilters).WithMany(n => n.Filter);
            modelBuilder.Entity<Models.Category>().HasMany(n => n.AssosiatedItems).WithMany(n => n.Categories);
            modelBuilder.Entity<Models.Category>().HasMany(n => n.Children).WithOptional(n => n.Parent);

            modelBuilder.Entity<Models.Item>().HasKey(n => n.Id);

    




        }
    }
}
