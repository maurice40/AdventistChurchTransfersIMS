namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remdetuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Userdetails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Userdetails", new[] { "UserId" });
            RenameColumn(table: "dbo.Userdetails", name: "UserId", newName: "ApplicationUser_Id");
            AlterColumn("dbo.Userdetails", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Userdetails", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Userdetails");
            AddPrimaryKey("dbo.Userdetails", "Id");
            CreateIndex("dbo.Userdetails", "ApplicationUser_Id");
            AddForeignKey("dbo.Userdetails", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Userdetails", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Userdetails", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.Userdetails");
            AddPrimaryKey("dbo.Userdetails", "UserId");
            AlterColumn("dbo.Userdetails", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Userdetails", "ApplicationUser_Id", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.Userdetails", name: "ApplicationUser_Id", newName: "UserId");
            CreateIndex("dbo.Userdetails", "UserId");
            AddForeignKey("dbo.Userdetails", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
