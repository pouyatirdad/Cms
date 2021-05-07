namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtagsinpage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pages", "Tags", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pages", "Tags");
        }
    }
}
