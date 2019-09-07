namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDivisionInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Contacts = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Provinces", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Provinces", "DivisionId");
            AddForeignKey("dbo.Provinces", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provinces", "DivisionId", "dbo.Divisions");
            DropIndex("dbo.Provinces", new[] { "DivisionId" });
            DropColumn("dbo.Provinces", "DivisionId");
            DropTable("dbo.Divisions");
        }
    }
}
