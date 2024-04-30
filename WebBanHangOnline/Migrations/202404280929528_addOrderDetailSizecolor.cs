namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderDetailSizecolor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_OrderDetail", "ColorName", c => c.String());
            AddColumn("dbo.tb_OrderDetail", "SizeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_OrderDetail", "SizeName");
            DropColumn("dbo.tb_OrderDetail", "ColorName");
        }
    }
}
