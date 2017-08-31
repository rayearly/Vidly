namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateMovieTable : DbMigration
    {
        // Repopulate the Movie table using correct datetime format value for sql.
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Hangover', 'Comedy', '2012-06-18 10:34:09', 10)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Die Hard', 'Action', '2012-06-18 10:34:09', 24)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('The Terminator', 'Action', '2012-06-18 10:34:09', 35)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Toy Story', 'Comedy', '2012-06-18 10:34:09', 17)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Titanic', 'Romance', '2012-06-18 10:34:09', 42)");
        }
        
        public override void Down()
        {
        }
    }
}
