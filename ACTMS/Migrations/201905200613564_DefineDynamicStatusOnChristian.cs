namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineDynamicStatusOnChristian : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Christians", "StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Christians", "Photo", c => c.String(nullable: false));
            CreateIndex("dbo.Christians", "StatusId");
            AddForeignKey("dbo.Christians", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.Christians", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Christians", "Status", c => c.String(nullable: false));
            DropForeignKey("dbo.Christians", "StatusId", "dbo.Status");
            DropIndex("dbo.Christians", new[] { "StatusId" });
            AlterColumn("dbo.Christians", "Photo", c => c.String());
            DropColumn("dbo.Christians", "StatusId");
        }
    }
}
