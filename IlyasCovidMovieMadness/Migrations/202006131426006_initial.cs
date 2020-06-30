namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Text = c.String(maxLength: 1000),
                        UserRatig = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateEdited = c.DateTime(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        Text = c.String(maxLength: 1000),
                        PostRating = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateEdited = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Movies", t => t.PostId)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostId", "dbo.Movies");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropIndex("dbo.Posts", new[] { "PostId" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropTable("dbo.Movies");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
