namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postremovedMovieTitle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "MovieTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "MovieTitle", c => c.String(maxLength: 50));
        }
    }
}
