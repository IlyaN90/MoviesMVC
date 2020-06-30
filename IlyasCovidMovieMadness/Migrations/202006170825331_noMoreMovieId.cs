namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noMoreMovieId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "MovieId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "MovieId", c => c.Int(nullable: false));
        }
    }
}
