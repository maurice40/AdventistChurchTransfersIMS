namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transfers", "Churrch_Id", c => c.Int());
            CreateIndex("dbo.Transfers", "Churrch_Id");
            AddForeignKey("dbo.Transfers", "Churrch_Id", "dbo.Churrches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "Churrch_Id", "dbo.Churrches");
            DropIndex("dbo.Transfers", new[] { "Churrch_Id" });
            DropColumn("dbo.Transfers", "Churrch_Id");
        }
    }
}
