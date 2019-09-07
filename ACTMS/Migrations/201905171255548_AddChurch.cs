namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChurch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Churches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Churches", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.Churches", new[] { "ProvinceId" });
            DropTable("dbo.Provinces");
            DropTable("dbo.Churches");
        }
    }
}
