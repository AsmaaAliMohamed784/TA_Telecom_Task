namespace TA_Telecom_Task.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewTableSMSPhoneNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMSPhoneNumber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        PhoneNumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneNumber", t => t.PhoneNumId, cascadeDelete: true)
                .Index(t => t.PhoneNumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SMSPhoneNumber", "PhoneNumId", "dbo.PhoneNumber");
            DropIndex("dbo.SMSPhoneNumber", new[] { "PhoneNumId" });
            DropTable("dbo.SMSPhoneNumber");
        }
    }
}
