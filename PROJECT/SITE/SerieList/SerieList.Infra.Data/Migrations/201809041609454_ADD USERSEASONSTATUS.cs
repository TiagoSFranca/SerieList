namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSERSEASONSTATUS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserSeasonStatus",
                c => new
                    {
                        IdUserSeasonStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUserSeasonStatus);
            
        }
        
        public override void Down()
        {
            DropTable("UserSeasonStatus");
        }
    }
}
