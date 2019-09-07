namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accountinfoes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Accountinfoes", new[] { "UserId" });
            CreateTable(
                "dbo.Userdetails",
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
            
            DropTable("dbo.Accountinfoes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.UserId);
            
            DropForeignKey("dbo.Userdetails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Userdetails", new[] { "UserId" });
            DropTable("dbo.Userdetails");
            CreateIndex("dbo.Accountinfoes", "UserId");
            AddForeignKey("dbo.Accountinfoes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
