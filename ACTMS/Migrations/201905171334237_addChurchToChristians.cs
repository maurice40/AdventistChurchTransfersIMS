namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChurchToChristians : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Christians", "ChurchId", c => c.Int(nullable: false));
            CreateIndex("dbo.Christians", "ChurchId");
            AddForeignKey("dbo.Christians", "ChurchId", "dbo.Churches", "Id", cascadeDelete: true);
            DropColumn("dbo.Christians", "Church");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Christians", "Church", c => c.Int(nullable: false));
            DropForeignKey("dbo.Christians", "ChurchId", "dbo.Churches");
            DropIndex("dbo.Christians", new[] { "ChurchId" });
            DropColumn("dbo.Christians", "ChurchId");
        }
    }
}
