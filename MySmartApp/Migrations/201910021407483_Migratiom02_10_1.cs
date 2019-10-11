namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratiom02_10_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevicesViewModels", "RoomId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DevicesViewModels", "RoomId");
        }
    }
}
