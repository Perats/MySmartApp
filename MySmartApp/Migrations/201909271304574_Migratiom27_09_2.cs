namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migratiom27_09_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DevicesViewModels", "Schedule_Id", c => c.Int());
            CreateIndex("dbo.DevicesViewModels", "Schedule_Id");
            AddForeignKey("dbo.DevicesViewModels", "Schedule_Id", "dbo.Schedules", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DevicesViewModels", "Schedule_Id", "dbo.Schedules");
            DropIndex("dbo.DevicesViewModels", new[] { "Schedule_Id" });
            DropColumn("dbo.DevicesViewModels", "Schedule_Id");
        }
    }
}
