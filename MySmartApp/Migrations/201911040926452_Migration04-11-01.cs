namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration041101 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Devices", "RoomId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Devices", "RoomId", c => c.Int(nullable: false));
        }
    }
}
