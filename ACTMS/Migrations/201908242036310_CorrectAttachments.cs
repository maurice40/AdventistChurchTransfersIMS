namespace ACTMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectAttachments : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Attachment_Insert",
                p => new
                {
                    Title = p.String(),
                    AUrl = p.String(),
                    Status = p.String(),
                    ChristianId = p.Int(),
                },
                body:
                    @"INSERT [dbo].[Attachments]([Title], [Aurl], [Status], [ChristianId])  
                      VALUES (@Title, @Aurl, @Status, @ChristianId)  
                   "
            );  
            
              
        }  
        
        
        public override void Down()
        {
      
            DropStoredProcedure("dbo.Attachment_Insert");
        }
    }
}
