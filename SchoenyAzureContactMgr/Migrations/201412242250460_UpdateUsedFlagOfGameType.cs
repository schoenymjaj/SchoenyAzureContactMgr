namespace SchoenyAzureContactMgr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUsedFlagOfGameType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.GameType SET UsedFlag = 1"); 

        }
        
        public override void Down()
        {
            Sql("UPDATE dbo.GameType SET UsedFlag = NULL");
        }
    }
}
