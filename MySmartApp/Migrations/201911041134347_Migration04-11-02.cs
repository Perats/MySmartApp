namespace MySmartApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration041102 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "Temperature", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "Temperature");
        }
    }
}
