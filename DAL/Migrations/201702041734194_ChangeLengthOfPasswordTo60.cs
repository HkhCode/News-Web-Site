namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfPasswordTo60 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "HashPassword", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "HashPassword", c => c.String(maxLength: 30));
        }
    }
}
