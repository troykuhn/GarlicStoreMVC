namespace GarlicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddksd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Rating");
        }
    }
}
