namespace NoExit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveEmail : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.QuestRequests", "Email");
            DropColumn("dbo.QuestRequests", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuestRequests", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.QuestRequests", "Email", c => c.String());
        }
    }
}
