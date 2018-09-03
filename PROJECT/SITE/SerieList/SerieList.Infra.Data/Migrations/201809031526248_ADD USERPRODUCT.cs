namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDUSERPRODUCT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserProduct",
                c => new
                    {
                        IdUser = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        IdUserProductStatus = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdUser, t.IdProduct })
                .ForeignKey("UserProductStatus", t => t.IdUserProductStatus)
                .ForeignKey("User", t => t.IdUser)
                .ForeignKey("Product", t => t.IdProduct);
            
        }
        
        public override void Down()
        {
            DropForeignKey("UserProduct", "IdProduct", "Product");
            DropForeignKey("UserProduct", "IdUser", "User");
            DropForeignKey("UserProduct", "IdUserProductStatus", "UserProductStatus");
            DropTable("UserProduct");
        }
    }
}
