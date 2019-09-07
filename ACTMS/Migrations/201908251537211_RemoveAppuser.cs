namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAppuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Churrches", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Churrches", new[] { "ApplicationUserId" });
        }
        
        public override void Down()
        {
            AddColumn("dbo.Churrches", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Churrches", "ApplicationUserId");
            AddForeignKey("dbo.Churrches", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
