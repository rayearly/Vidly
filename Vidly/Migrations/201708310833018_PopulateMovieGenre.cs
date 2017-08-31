namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (2, 'Comedy')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (3, 'Romance')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (4, 'Family')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (5, 'Thriller')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (6, 'Horror')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (7, 'Fantasy')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (8, 'Anime')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (9, 'Drama')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (10, 'Science Fiction')");

        }
        
        public override void Down()
        {
        }
    }
}
