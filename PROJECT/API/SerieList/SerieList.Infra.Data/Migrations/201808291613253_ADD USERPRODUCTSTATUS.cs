namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSERPRODUCTSTATUS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserProductStatus",
                c => new
                    {
                        IdUserProductStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUserProductStatus);
            
        }
        
        public override void Down()
        {
            DropTable("UserProductStatus");
        }
    }
}
