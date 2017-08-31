namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterStockQuantityDataType : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ALTER COLUMN StockQUantity int");
        }
        
        public override void Down()
        {
        }
    }
}
