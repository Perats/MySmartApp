namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratiom26_09_13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DevicesViewModels", "Rooms_Id", "dbo.Rooms");
            DropIndex("dbo.DevicesViewModels", new[] { "Rooms_Id" });
            AddColumn("dbo.DevicesViewModels", "Rooms", c => c.String());
            DropColumn("dbo.DevicesViewModels", "Rooms_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DevicesViewModels", "Rooms_Id", c => c.Int());
            DropColumn("dbo.DevicesViewModels", "Rooms");
            CreateIndex("dbo.DevicesViewModels", "Rooms_Id");
            AddForeignKey("dbo.DevicesViewModels", "Rooms_Id", "dbo.Rooms", "Id");
        }
    }
}
