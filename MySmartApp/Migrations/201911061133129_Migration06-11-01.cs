namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration061101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Humidity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Humidity");
        }
    }
}
