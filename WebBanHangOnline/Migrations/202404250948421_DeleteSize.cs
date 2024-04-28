namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Product", "ProductSizes_id", "dbo.ProductSizes");
            DropIndex("dbo.tb_Product", new[] { "ProductSizes_id" });
            DropColumn("dbo.tb_Product", "ProductSizeID");
            DropColumn("dbo.tb_Product", "ProductSizes_id");
            DropTable("dbo.ProductSizes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductSizes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        SizeName = c.String(nullable: false, maxLength: 150),
                        CreateBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Modifieddate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.tb_Product", "ProductSizes_id", c => c.Int());
            AddColumn("dbo.tb_Product", "ProductSizeID", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Product", "ProductSizes_id");
            AddForeignKey("dbo.tb_Product", "ProductSizes_id", "dbo.ProductSizes", "id");
        }
    }
}
