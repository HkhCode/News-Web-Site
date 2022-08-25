namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageToNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "ImageData", c => c.Binary());
            AddColumn("dbo.News", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "ImageMimeType");
            DropColumn("dbo.News", "ImageData");
        }
    }
}
