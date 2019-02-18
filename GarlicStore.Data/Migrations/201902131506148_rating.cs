namespace GarlicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Review", "Rating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Review", "Rating", c => c.Int(nullable: false));
        }
    }
}
