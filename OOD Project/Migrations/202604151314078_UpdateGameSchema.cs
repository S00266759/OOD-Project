namespace OOD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGameSchema : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Games", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
