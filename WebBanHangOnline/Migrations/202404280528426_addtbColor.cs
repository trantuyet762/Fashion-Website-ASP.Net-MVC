namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbColor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Color",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_ProductColor",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ProductID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_Color", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.tb_Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.ColorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ProductColor", "ProductID", "dbo.tb_Product");
            DropForeignKey("dbo.tb_ProductColor", "ColorID", "dbo.tb_Color");
            DropIndex("dbo.tb_ProductColor", new[] { "ColorID" });
            DropIndex("dbo.tb_ProductColor", new[] { "ProductID" });
            DropTable("dbo.tb_ProductColor");
            DropTable("dbo.tb_Color");
        }
    }
}
