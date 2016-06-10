namespace Omnicatz.Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WHAAAAAAAAAAG : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NonExclusiveRef = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        IsWhiteList = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Inventory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Inventory_Id)
                .Index(t => t.Inventory_Id);
            
            CreateTable(
                "dbo.CategoryInventories",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Inventory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Inventory_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Inventory_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Inventory_Id);
            
            CreateTable(
                "dbo.CategoryItems",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Item_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Parent_Id", "dbo.Categories");
            DropForeignKey("dbo.CategoryItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.CategoryItems", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.CategoryInventories", "Inventory_Id", "dbo.Items");
            DropForeignKey("dbo.CategoryInventories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Items", "Inventory_Id", "dbo.Items");
            DropIndex("dbo.CategoryItems", new[] { "Item_Id" });
            DropIndex("dbo.CategoryItems", new[] { "Category_Id" });
            DropIndex("dbo.CategoryInventories", new[] { "Inventory_Id" });
            DropIndex("dbo.CategoryInventories", new[] { "Category_Id" });
            DropIndex("dbo.Items", new[] { "Inventory_Id" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropTable("dbo.CategoryItems");
            DropTable("dbo.CategoryInventories");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
