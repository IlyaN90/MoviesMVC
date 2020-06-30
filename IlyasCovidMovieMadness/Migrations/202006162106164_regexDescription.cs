namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regexDescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(maxLength: 50));
        }
    }
}
