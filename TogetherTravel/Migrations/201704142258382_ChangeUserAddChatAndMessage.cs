namespace TogetherTravel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserAddChatAndMessage : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCreatorId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreator_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserCreator_Id, cascadeDelete: true)
                .Index(t => t.UserCreator_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCreatorId = c.Int(nullable: false),
                        ChatId = c.Int(nullable: false),
                        MessageText = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        UserCreator_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserCreator_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chats", t => t.ChatId, cascadeDelete: true)
                .Index(t => t.ChatId)
                .Index(t => t.UserCreator_Id);
            
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
            
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.Users", "SecurityStamp", c => c.String());
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Users", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "SecondName", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "LatitudeCoord", c => c.Double());
            AlterColumn("dbo.Users", "LongitudeCoord", c => c.Double());
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UserToChat", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserToChat", "ChatId", "dbo.Chats");
            DropForeignKey("dbo.Chats", "UserCreator_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "ChatId", "dbo.Chats");
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
            DropIndex("dbo.Messages", new[] { "UserCreator_Id" });
            DropIndex("dbo.Messages", new[] { "ChatId" });
            DropIndex("dbo.Chats", new[] { "UserCreator_Id" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "LongitudeCoord", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "LatitudeCoord", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "SecondName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "AccessFailedCount");
            DropColumn("dbo.Users", "LockoutEnabled");
            DropColumn("dbo.Users", "LockoutEndDateUtc");
            DropColumn("dbo.Users", "TwoFactorEnabled");
            DropColumn("dbo.Users", "PhoneNumberConfirmed");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "SecurityStamp");
            DropColumn("dbo.Users", "PasswordHash");
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "Email");
            DropTable("dbo.UserToChat");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Messages");
            DropTable("dbo.Chats");
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
