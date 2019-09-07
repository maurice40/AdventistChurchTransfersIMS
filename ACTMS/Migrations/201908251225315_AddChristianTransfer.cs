namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChristianTransfer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        Added_at = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        TransferReasonId = c.Int(nullable: false),
                        ChristianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Christians", t => t.ChristianId, cascadeDelete: true)
                .ForeignKey("dbo.TransferReasons", t => t.TransferReasonId, cascadeDelete: true)
                .Index(t => t.ChristianId)
                .Index(t => t.TransferReasonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "TransferReasonId", "dbo.TransferReasons");
            DropForeignKey("dbo.Transfers", "ChristianId", "dbo.Christians");
            DropIndex("dbo.Transfers", new[] { "TransferReasonId" });
            DropIndex("dbo.Transfers", new[] { "ChristianId" });
            DropTable("dbo.Transfers");
        }
    }
}
