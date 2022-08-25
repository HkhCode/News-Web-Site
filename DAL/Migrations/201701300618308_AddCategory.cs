namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.News", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "CategoryId");
            AddForeignKey("dbo.News", "CategoryId", "dbo.NewsCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "CategoryId", "dbo.NewsCategories");
            DropIndex("dbo.News", new[] { "CategoryId" });
            DropColumn("dbo.News", "CategoryId");
            DropTable("dbo.NewsCategories");
        }
    }
}
