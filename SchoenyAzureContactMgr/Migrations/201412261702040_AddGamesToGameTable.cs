namespace SchoenyAzureContactMgr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamesToGameTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Game (GameTypeId, Name, [Description])select gt.id AS GameTypeId,gt.Name + '!!!#' AS Name, gt.Description + '!!!#' AS [Description] from GameType gt");

        }
        
        public override void Down()
        {
            Sql("truncate table Game");
        }
    }
}
