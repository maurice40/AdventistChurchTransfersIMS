namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReInsertDivionsForTest : DbMigration
    {
        public override void Up()
        {
            //Sql("SET IDENTITY_INSERT Divisions ON");
            Sql("INSERT INTO Divisions (Name, Contacts) VALUES ('EAST', '0782184565')");
            Sql("INSERT INTO Divisions (Name, Contacts) VALUES ('WEST', '0782184565')");
            Sql("INSERT INTO Divisions (Name, Contacts) VALUES ('NORTH', '0782184565')");
            Sql("INSERT INTO Divisions (Name, Contacts) VALUES ('SOUTH', '0782184565')");
            Sql("INSERT INTO Divisions (Name, Contacts) VALUES ('KIGALI', '0782184565')");
            //Sql("SET IDENTITY_INSERT Divisions OFF");
        }
        
        public override void Down()
        {
        }
    }
}
