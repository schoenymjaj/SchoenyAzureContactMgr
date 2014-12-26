namespace SchoenyAzureContactMgr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringColumnToGameType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameType", "AnotherTextField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameType", "AnotherTextField");
        }
    }
}
