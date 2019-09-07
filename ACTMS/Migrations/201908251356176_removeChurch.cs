namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeChurch : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
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
    }
}
