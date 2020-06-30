namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Description");
        }
    }
}
