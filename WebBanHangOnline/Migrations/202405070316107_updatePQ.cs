namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePQ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductQuantity",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        QuantityProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_Color", t => t.ColorId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.tb_Size", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeId)
                .Index(t => t.ColorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductQuantity", "SizeId", "dbo.tb_Size");
            DropForeignKey("dbo.ProductQuantity", "ProductId", "dbo.tb_Product");
            DropForeignKey("dbo.ProductQuantity", "ColorId", "dbo.tb_Color");
            DropIndex("dbo.ProductQuantity", new[] { "ColorId" });
            DropIndex("dbo.ProductQuantity", new[] { "SizeId" });
            DropIndex("dbo.ProductQuantity", new[] { "ProductId" });
            DropTable("dbo.ProductQuantity");
        }
    }
}
