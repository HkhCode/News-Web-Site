namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowFieldToNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Show", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Show");
        }
    }
}
