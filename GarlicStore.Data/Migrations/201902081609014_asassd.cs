namespace GarlicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asassd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Product", "SKU");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Product", "SKU", c => c.String(nullable: false));
        }
    }
}
