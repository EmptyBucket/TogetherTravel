namespace TogetherTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndChatAndMessage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreator_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserCreator_Id)
                .Index(t => t.UserCreator_Id);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreator_Id = c.String(nullable: false, maxLength: 128),
                        Chat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserCreator_Id)
                .ForeignKey("dbo.Chat", t => t.Chat_Id)
                .Index(t => t.UserCreator_Id)
                .Index(t => t.Chat_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 200),
                        SecondName = c.String(maxLength: 200),
                        BirthDay = c.DateTime(),
                        LatitudeCoord = c.Double(),
                        LongitudeCoord = c.Double(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserToRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserToChat",
                c => new
                    {
                        ChatId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ChatId, t.UserId })
                .ForeignKey("dbo.Chat", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChatId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserToRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserToChat", "UserId", "dbo.User");
            DropForeignKey("dbo.UserToChat", "ChatId", "dbo.Chat");
            DropForeignKey("dbo.Chat", "UserCreator_Id", "dbo.User");
            DropForeignKey("dbo.Message", "Chat_Id", "dbo.Chat");
            DropForeignKey("dbo.Message", "UserCreator_Id", "dbo.User");
            DropForeignKey("dbo.UserToRole", "UserId", "dbo.User");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropIndex("dbo.UserToChat", new[] { "UserId" });
            DropIndex("dbo.UserToChat", new[] { "ChatId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserToRole", new[] { "RoleId" });
            DropIndex("dbo.UserToRole", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.Message", new[] { "Chat_Id" });
            DropIndex("dbo.Message", new[] { "UserCreator_Id" });
            DropIndex("dbo.Chat", new[] { "UserCreator_Id" });
            DropTable("dbo.UserToChat");
            DropTable("dbo.Role");
            DropTable("dbo.UserToRole");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Message");
            DropTable("dbo.Chat");
        }
    }
}
