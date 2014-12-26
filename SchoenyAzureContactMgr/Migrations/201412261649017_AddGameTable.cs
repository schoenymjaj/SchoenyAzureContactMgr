namespace SchoenyAzureContactMgr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        GameTypeId = c.Long(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(maxLength: 200),
                        DateCreated = c.DateTime(),
                        CreatedBy = c.String(),
                        DateUpdated = c.DateTime(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameType", t => t.GameTypeId, cascadeDelete: true)
                .Index(t => t.GameTypeId);
            
            AddColumn("dbo.GameType", "Comment", c => c.String());


        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "GameTypeId", "dbo.GameType");
            DropIndex("dbo.Game", new[] { "GameTypeId" });
            DropColumn("dbo.GameType", "Comment");
            DropTable("dbo.Game");
        }
    }
}
