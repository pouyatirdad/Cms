namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeimagerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "Image", c => c.String(nullable: false));
        }
    }
}
