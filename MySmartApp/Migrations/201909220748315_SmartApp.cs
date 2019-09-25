namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmartApp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DevicesViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        LastPinDate = c.DateTime(nullable: false),
                        DeviceStatus = c.Byte(nullable: false),
                        RoomType = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DevicesViewModels");
        }
    }
}
