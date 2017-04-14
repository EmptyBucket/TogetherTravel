using System.Data.Entity.Migrations;

namespace TogetherTravel.Migrations
{
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        SecondName = c.String(nullable: false, maxLength: 200),
                        BirthDay = c.DateTime(),
                        LatitudeCoord = c.Double(nullable: false),
                        LongitudeCoord = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
