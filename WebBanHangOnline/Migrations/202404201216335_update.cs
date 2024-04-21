namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.tb_Subscribe");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_Subscribe",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.Subs");
        }
    }
}
