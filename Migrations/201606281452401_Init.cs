namespace NoExit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FIO = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        QuestId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quests", t => t.QuestId, cascadeDelete: true)
                .Index(t => t.QuestId);
            
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                        QuestId = c.Int(nullable: false),
                        IsReserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestRequests", "QuestId", "dbo.Quests");
            DropIndex("dbo.QuestRequests", new[] { "QuestId" });
            DropTable("dbo.Quests");
            DropTable("dbo.QuestRequests");
        }
    }
}
