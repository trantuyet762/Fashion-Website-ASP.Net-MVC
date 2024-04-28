namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSizetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductSize",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ProductID = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.tb_Size", t => t.SizeID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SizeID);
            
            CreateTable(
                "dbo.tb_Size",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SizeName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductSize", "SizeID", "dbo.tb_Size");
            DropForeignKey("dbo.tb_ProductSize", "ProductID", "dbo.tb_Product");
            DropIndex("dbo.tb_ProductSize", new[] { "SizeID" });
            DropIndex("dbo.tb_ProductSize", new[] { "ProductID" });
            DropTable("dbo.tb_Size");
            DropTable("dbo.tb_ProductSize");
        }
    }
}
