namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSliderInPage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Slider", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Slider");
        }
    }
}
