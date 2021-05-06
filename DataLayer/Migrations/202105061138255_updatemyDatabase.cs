namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemyDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Image");
        }
    }
}
