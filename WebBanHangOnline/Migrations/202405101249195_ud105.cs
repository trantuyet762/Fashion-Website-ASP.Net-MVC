namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ud105 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Order", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.tb_Order", "CustomerId");
            AddForeignKey("dbo.tb_Order", "CustomerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Order", "CustomerId", "dbo.AspNetUsers");
            DropIndex("dbo.tb_Order", new[] { "CustomerId" });
            AlterColumn("dbo.tb_Order", "CustomerId", c => c.String());
        }
    }
}
