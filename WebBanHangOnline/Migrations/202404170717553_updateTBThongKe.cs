namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTBThongKe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_ThongKe", newName: "ThongKes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ThongKes", newName: "tb_ThongKe");
        }
    }
}
