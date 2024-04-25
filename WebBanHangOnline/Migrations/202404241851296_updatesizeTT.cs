namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesizeTT : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductSizes", "Title", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSizes", "Title", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
