namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatereview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ReviewProduct", "OrderId", c => c.Int());
            CreateIndex("dbo.tb_ReviewProduct", "OrderId");
            AddForeignKey("dbo.tb_ReviewProduct", "OrderId", "dbo.tb_Order", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_ReviewProduct", "OrderId", "dbo.tb_Order");
            DropIndex("dbo.tb_ReviewProduct", new[] { "OrderId" });
            DropColumn("dbo.tb_ReviewProduct", "OrderId");
        }
    }
}
