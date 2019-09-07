namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectProvinceViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Churches", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Churches", "Address", c => c.String());
        }
    }
}
