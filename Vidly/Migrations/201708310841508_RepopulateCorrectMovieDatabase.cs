namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateCorrectMovieDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Id, Name, DateAdded, StockQuantity, ReleaseDate, MovieGenreId) VALUES (1, 'Hangover', 10/02/2010, 12, 09/02/2010, 2)");
            Sql("INSERT INTO Movies (Id, Name, DateAdded, StockQuantity, ReleaseDate, MovieGenreId) VALUES (2, 'Die Hard', 01/03/2011, 32, 29/02/2011, 1)");
            Sql("INSERT INTO Movies (Id, Name, DateAdded, StockQuantity, ReleaseDate, MovieGenreId) VALUES (3, 'The Terminator', 12/10/1998, 44, 11/10/1998, 1)");
            Sql("INSERT INTO Movies (Id, Name, DateAdded, StockQuantity, ReleaseDate, MovieGenreId) VALUES (4, 'Toy Story', 07/12/2002, 9, 06/12/2002, 4)");
            Sql("INSERT INTO Movies (Id, Name, DateAdded, StockQuantity, ReleaseDate, MovieGenreId) VALUES (5, 'Titanic', 17/02/1990, 27, 16/02/1990, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
