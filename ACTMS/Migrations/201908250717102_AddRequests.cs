namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time_Added = c.DateTime(nullable: false),
                        Comment = c.String(),
                        ChristianId = c.Int(nullable: false),
                        Status = c.String(),
                        ChurchId = c.Int(nullable: false),
                        SupportedDoc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
                
        }
        
        public override void Down()
        {
            DropTable("dbo.Requests");
        }
    }
}
