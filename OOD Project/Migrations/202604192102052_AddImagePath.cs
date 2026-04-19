namespace OOD_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "ImagePath");
        }
    }
}
