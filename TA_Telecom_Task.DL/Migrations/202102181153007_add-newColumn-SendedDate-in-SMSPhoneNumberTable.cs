namespace TA_Telecom_Task.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewColumnSendedDateinSMSPhoneNumberTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SMSPhoneNumber", "SendedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SMSPhoneNumber", "SendedDate");
        }
    }
}
