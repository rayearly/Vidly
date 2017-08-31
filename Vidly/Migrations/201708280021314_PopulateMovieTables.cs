namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Hangover', 'Comedy', 10/02/2010, 10)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Die Hard', 'Action', 01/03/2011, 24)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('The Terminator', 'Action', 12/10/1998, 35)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Toy Story', 'Comedy', 07/12/2002, 17)");
            Sql("INSERT INTO Movies (Name, Genre, DateAdded, StockQuantity) VALUES ('Titanic', 'Romance', 17/02/1990, 42)");
        }
        
        public override void Down()
        {
        }
    }
}
