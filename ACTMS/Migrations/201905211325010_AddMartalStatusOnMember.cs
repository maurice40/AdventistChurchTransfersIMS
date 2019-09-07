namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMartalStatusOnMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Christians", "MartalStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Christians", "MartalStatus");
        }
    }
}
