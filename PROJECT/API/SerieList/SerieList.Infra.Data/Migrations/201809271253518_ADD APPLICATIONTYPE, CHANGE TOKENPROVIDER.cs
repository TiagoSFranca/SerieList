namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDAPPLICATIONTYPECHANGETOKENPROVIDER : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ApplicationType",
                c => new
                    {
                        IdApplicationType = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 64, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdApplicationType);
            
            AddColumn("TokenProvider", "IdApplicationType", c => c.Int(nullable: false));
            AddForeignKey("TokenProvider", "IdApplicationType", "ApplicationType", "IdApplicationType");
        }
        
        public override void Down()
        {
            DropForeignKey("TokenProvider", "IdApplicationType", "ApplicationType");
            DropColumn("TokenProvider", "IdApplicationType");
            DropTable("ApplicationType");
        }
    }
}
