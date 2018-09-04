namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSEREPISODE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserEpisode",
                c => new
                    {
                        IdUser = c.Int(nullable: false),
                        IdEpisode = c.Int(nullable: false),
                        IdUserEpisodeStatus = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdUser, t.IdEpisode })
                .ForeignKey("UserEpisodeStatus", t => t.IdUserEpisodeStatus)
                .ForeignKey("User", t => t.IdUser)
                .ForeignKey("Episode", t => t.IdEpisode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("UserEpisode", "IdEpisode", "Episode");
            DropForeignKey("UserEpisode", "IdUser", "User");
            DropForeignKey("UserEpisode", "IdUserEpisodeStatus", "UserEpisodeStatus");
            DropTable("UserEpisode");
        }
    }
}
