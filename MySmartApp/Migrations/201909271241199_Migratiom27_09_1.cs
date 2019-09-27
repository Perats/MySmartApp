namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratiom27_09_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceId = c.Int(nullable: false),
                        DeviceName = c.String(),
                        ScheduleName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DeviceStatus = c.Byte(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schedules");
        }
    }
}
