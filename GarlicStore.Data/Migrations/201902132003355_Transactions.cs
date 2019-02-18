namespace GarlicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Transaction", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "DateOfTransaction", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transaction", "OwnerId");
            DropColumn("dbo.Transaction", "Price");
            DropColumn("dbo.Transaction", "Quantity");
        }
    }
}
