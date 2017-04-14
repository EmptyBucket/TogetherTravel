namespace TogetherTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChatMessageRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCreatorId = c.Int(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                        User_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserCreatorId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.UserCreatorId)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCreatorId = c.Int(nullable: false),
                        ChatId = c.Int(nullable: false),
                        MessageText = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserCreatorId, cascadeDelete: true)
                .Index(t => t.UserCreatorId)
                .Index(t => t.ChatId);
            
            AddColumn("dbo.Users", "Chat_Id", c => c.Int());
            CreateIndex("dbo.Users", "Chat_Id");
            AddForeignKey("dbo.Users", "Chat_Id", "dbo.Chats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Chats", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.Chats", "UserCreatorId", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserCreatorId", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chats");
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Messages", new[] { "UserCreatorId" });
            DropIndex("dbo.Chats", new[] { "User_Id1" });
            DropIndex("dbo.Chats", new[] { "User_Id" });
            DropIndex("dbo.Chats", new[] { "UserCreatorId" });
            DropIndex("dbo.Users", new[] { "Chat_Id" });
            DropColumn("dbo.Users", "Chat_Id");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
        }
    }
}
