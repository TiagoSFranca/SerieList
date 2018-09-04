namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSEREPISODESTATUS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserEpisodeStatus",
                c => new
                    {
                        IdUserEpisodeStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUserEpisodeStatus);
            
        }
        
        public override void Down()
        {
            DropTable("UserEpisodeStatus");
        }
    }
}
