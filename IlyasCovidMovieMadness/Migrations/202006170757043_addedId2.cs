namespace IlyasCovidMovieMadness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedId2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String());
        }
    }
}
