namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixViewsTypeINPageModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Views", c => c.String(nullable: false));
        }
    }
}
