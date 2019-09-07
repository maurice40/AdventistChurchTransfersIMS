namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAdditionalUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
            AddColumn("dbo.AspNetUsers", "Names", c => c.String());
            AddColumn("dbo.AspNetUsers", "Levels", c => c.String());
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Email");
            DropColumn("dbo.AspNetUsers", "Levels");
            DropColumn("dbo.AspNetUsers", "Names");
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
