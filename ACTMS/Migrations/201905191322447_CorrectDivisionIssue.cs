namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectDivisionIssue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Christians", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.Christians", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.Christians", "Sex", c => c.String(nullable: false));
            AlterColumn("dbo.Christians", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Churches", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Provinces", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Divisions", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Divisions", "Name", c => c.String());
            AlterColumn("dbo.Provinces", "Name", c => c.String());
            AlterColumn("dbo.Churches", "Name", c => c.String());
            AlterColumn("dbo.Christians", "Status", c => c.String());
            AlterColumn("dbo.Christians", "Sex", c => c.String());
            AlterColumn("dbo.Christians", "Lastname", c => c.String());
            AlterColumn("dbo.Christians", "Firstname", c => c.String());
        }
    }
}
