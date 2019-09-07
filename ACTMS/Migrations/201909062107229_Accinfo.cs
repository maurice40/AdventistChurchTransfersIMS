namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountinfoes",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        RoleName = c.String(nullable: false),
                        ChurrchId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accountinfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Accountinfoes", new[] { "UserId" });
            DropTable("dbo.Accountinfoes");
        }
    }
}
