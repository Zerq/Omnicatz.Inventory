using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Omnicatz.Inventory.Test {
    [TestClass]
    public class InventoryCanContainInventory{
        Omnicatz.Inventory.Data.Context db = new Omnicatz.Inventory.Data.Context("DefaultConnection");


        [TestMethod]
        public void TestMethod1() {
            var boxA = new Models.Inventory() { Name = "Box A" };
          //  var boxB = new Models.Inventory() { Name = "Box B" , Items= new System.Collections.Generic.List<Models.Item>() { boxA } };
            db.Inventories.Add(boxA);
          //  db.Inventories.Add(boxB);
            db.SaveChanges();


            Assert.Fail();

        }


    }
}
