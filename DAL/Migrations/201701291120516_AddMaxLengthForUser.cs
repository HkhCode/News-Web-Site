namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxLengthForUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "HashPassword", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Family", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Family", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "HashPassword", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
