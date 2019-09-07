namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeParents : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Christians", "Father", c => c.String(nullable: false));
            AlterColumn("dbo.Christians", "Mother", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Christians", "Mother", c => c.Int(nullable: false));
            AlterColumn("dbo.Christians", "Father", c => c.Int(nullable: false));
        }
    }
}
