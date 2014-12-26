namespace SchoenyAzureContactMgr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBoleanColumnToGameType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameType", "UsedFlag", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameType", "UsedFlag");
        }
    }
}
