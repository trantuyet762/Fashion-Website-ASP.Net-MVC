namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update294 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tb_ReviewProduct", "ProductId");
            AddForeignKey("dbo.tb_ReviewProduct", "ProductId", "dbo.tb_Product", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ReviewProduct", "ProductId", "dbo.tb_Product");
            DropIndex("dbo.tb_ReviewProduct", new[] { "ProductId" });
        }
    }
}
