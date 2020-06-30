namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostMovieTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "MovieTitle", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "MovieTitle");
        }
    }
}
