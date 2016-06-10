namespace Omnicatz.Inventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Class", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Class");
        }
    }
}
