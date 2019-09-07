namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChurrchh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churrches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(),
                        Contact = c.String(),
                        ProvinceId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ProvinceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Churrches", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Churrches", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Churrches", new[] { "ProvinceId" });
            DropIndex("dbo.Churrches", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Churrches");
        }
    }
}
