namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMoviesTableContent : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE Id > 0");
        }
        
        public override void Down()
        {
        }
    }
}
