namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCateProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Product", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Product", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
