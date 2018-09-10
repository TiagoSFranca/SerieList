namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSERSEASON : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserSeason",
                c => new
                    {
                        IdUser = c.Int(nullable: false),
                        IdSeason = c.Int(nullable: false),
                        IdUserSeasonStatus = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdUser, t.IdSeason })
                .ForeignKey("UserSeasonStatus", t => t.IdUserSeasonStatus)
                .ForeignKey("User", t => t.IdUser)
                .ForeignKey("Season", t => t.IdSeason);
            
        }
        
        public override void Down()
        {
            DropForeignKey("UserSeason", "IdSeason", "Season");
            DropForeignKey("UserSeason", "IdUser", "User");
            DropForeignKey("UserSeason", "IdUserSeasonStatus", "UserSeasonStatus");
            DropTable("UserSeason");
        }
    }
}
