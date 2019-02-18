namespace GarlicStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Review : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.Review", new[] { "Product_ProductId" });
            RenameColumn(table: "dbo.Review", name: "Product_ProductId", newName: "ProductId");
            AddColumn("dbo.Review", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Review", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "ProductId");
            AddForeignKey("dbo.Review", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "ProductId", "dbo.Product");
            DropIndex("dbo.Review", new[] { "ProductId" });
            AlterColumn("dbo.Review", "ProductId", c => c.Int());
            DropColumn("dbo.Review", "OwnerId");
            RenameColumn(table: "dbo.Review", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Review", "Product_ProductId");
            AddForeignKey("dbo.Review", "Product_ProductId", "dbo.Product", "ProductId");
        }
    }
}
