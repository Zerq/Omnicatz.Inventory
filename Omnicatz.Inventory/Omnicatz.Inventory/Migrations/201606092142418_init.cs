namespace Omnicatz.Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Parent_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Parent_Id)
                .Index(t => t.Parent_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NonExclusiveRef = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        IsWhiteList = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Invnetory_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Invnetory_Id)
                .Index(t => t.Invnetory_Id);
            
            CreateTable(
                "dbo.CategoryInvnetories",
                c => new
                    {
                        Category_Id = c.Guid(nullable: false),
                        Invnetory_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Invnetory_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Invnetory_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Invnetory_Id);
            
            CreateTable(
                "dbo.CategoryItems",
                c => new
                    {
                        Category_Id = c.Guid(nullable: false),
                        Item_Id = c.Guid(nullable: false),
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
            DropForeignKey("dbo.CategoryInvnetories", "Invnetory_Id", "dbo.Items");
            DropForeignKey("dbo.CategoryInvnetories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Items", "Invnetory_Id", "dbo.Items");
            DropIndex("dbo.CategoryItems", new[] { "Item_Id" });
            DropIndex("dbo.CategoryItems", new[] { "Category_Id" });
            DropIndex("dbo.CategoryInvnetories", new[] { "Invnetory_Id" });
            DropIndex("dbo.CategoryInvnetories", new[] { "Category_Id" });
            DropIndex("dbo.Items", new[] { "Invnetory_Id" });
            DropIndex("dbo.Categories", new[] { "Parent_Id" });
            DropTable("dbo.CategoryItems");
            DropTable("dbo.CategoryInvnetories");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
