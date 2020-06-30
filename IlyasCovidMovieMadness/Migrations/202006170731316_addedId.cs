namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "MovieId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "MovieId");
        }
    }
}
