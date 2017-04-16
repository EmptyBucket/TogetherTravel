namespace TogetherTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserAddMessageAndChat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreator_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserCreator_Id)
                .Index(t => t.UserCreator_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreator_Id = c.String(nullable: false, maxLength: 128),
                        Chat_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserCreator_Id)
                .ForeignKey("dbo.Chats", t => t.Chat_Id)
                .Index(t => t.UserCreator_Id)
                .Index(t => t.Chat_Id);
            
            CreateTable(
                "dbo.Users",
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
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
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
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
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
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ChatId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserToChat", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToChat", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.Chats", "UserCreator_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Chat_Id", "dbo.Chats");
            DropForeignKey("dbo.Messages", "UserCreator_Id", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropIndex("dbo.UserToChat", new[] { "UserId" });
            DropIndex("dbo.UserToChat", new[] { "ChatId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "Chat_Id" });
            DropIndex("dbo.Messages", new[] { "UserCreator_Id" });
            DropIndex("dbo.Chats", new[] { "UserCreator_Id" });
            DropTable("dbo.UserToChat");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
        }
    }
}
