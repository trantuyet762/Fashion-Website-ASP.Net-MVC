namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTBThongKe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThongKes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ThoiGian = c.DateTime(nullable: false),
                        SoTruyCap = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.tb_Product", "ViewCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "ViewCount");
            DropTable("dbo.ThongKes");
        }
    }
}
