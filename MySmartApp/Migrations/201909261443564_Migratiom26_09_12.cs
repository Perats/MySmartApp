namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratiom26_09_12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevicesViewModels", "Rooms_Id", c => c.Int());
            CreateIndex("dbo.DevicesViewModels", "Rooms_Id");
            AddForeignKey("dbo.DevicesViewModels", "Rooms_Id", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DevicesViewModels", "Rooms_Id", "dbo.Rooms");
            DropIndex("dbo.DevicesViewModels", new[] { "Rooms_Id" });
            DropColumn("dbo.DevicesViewModels", "Rooms_Id");
        }
    }
}
