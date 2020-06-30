namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredAttr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "Text", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Posts", "Text", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Posts", "Text", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Comments", "Text", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Comments", "UserName", c => c.String(maxLength: 50));
        }
    }
}
