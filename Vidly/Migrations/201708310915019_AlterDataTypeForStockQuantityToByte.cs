namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterDataTypeForStockQuantityToByte : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Movies ALTER COLUMN StockQUantity tinyint");
        }
        
        public override void Down()
        {
        }
    }
}
