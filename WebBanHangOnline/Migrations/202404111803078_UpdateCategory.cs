namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tb_Category", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "Description", c => c.String(maxLength: 150));
        }
    }
}
