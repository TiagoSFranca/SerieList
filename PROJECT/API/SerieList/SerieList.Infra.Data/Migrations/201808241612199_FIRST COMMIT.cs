namespace SerieList.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FIRSTCOMMIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Configuration",
                c => new
                    {
                        IdConfiguration = c.Int(nullable: false),
                        Key = c.String(nullable: false, maxLength: 256, unicode: false),
                        Value = c.String(nullable: false, maxLength: 256, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdConfiguration);
            
            CreateTable(
                "Episode",
                c => new
                    {
                        IdEpisode = c.Int(nullable: false, identity: true),
                        IdVisibility = c.Int(nullable: false),
                        IdEpisodeStatus = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        IdSeason = c.Int(),
                        Title = c.String(nullable: false, maxLength: 128, unicode: false),
                        Description = c.String(maxLength: 512, unicode: false),
                        Order = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdEpisode)
                .ForeignKey("EpisodeStatus", t => t.IdEpisodeStatus)
                .ForeignKey("Product", t => t.IdProduct)
                .ForeignKey("Season", t => t.IdSeason)
                .ForeignKey("User", t => t.IdUser)
                .ForeignKey("Visibility", t => t.IdVisibility);
            
            CreateTable(
                "EpisodeStatus",
                c => new
                    {
                        IdEpisodeStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdEpisodeStatus);
            
            CreateTable(
                "Product",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        IdProductStatus = c.Int(nullable: false),
                        IdProductType = c.Int(nullable: false),
                        IdVisibility = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("ProductStatus", t => t.IdProductStatus)
                .ForeignKey("ProductType", t => t.IdProductType)
                .ForeignKey("User", t => t.IdUser)
                .ForeignKey("Visibility", t => t.IdVisibility);
            
            CreateTable(
                "ProductProductCategory",
                c => new
                    {
                        IdProduct = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProduct, t.IdCategory })
                .ForeignKey("ProductCategory", t => t.IdCategory)
                .ForeignKey("Product", t => t.IdProduct);
            
            CreateTable(
                "ProductCategory",
                c => new
                    {
                        IdProductCategory = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductCategory);
            
            CreateTable(
                "ProductInfo",
                c => new
                    {
                        IdProduct = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128, unicode: false),
                        Description = c.String(maxLength: 512, unicode: false),
                        BeginAt = c.DateTime(nullable: false, precision: 0),
                        EndAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.IdProduct)
                .ForeignKey("Product", t => t.IdProduct);
            
            CreateTable(
                "ProductStatus",
                c => new
                    {
                        IdProductStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductStatus);
            
            CreateTable(
                "ProductType",
                c => new
                    {
                        IdProductType = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProductType);
            
            CreateTable(
                "Season",
                c => new
                    {
                        IdSeason = c.Int(nullable: false, identity: true),
                        IdVisibility = c.Int(nullable: false),
                        IdSeasonStatus = c.Int(nullable: false),
                        IdProduct = c.Int(nullable: false),
                        IdUser = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 128, unicode: false),
                        Description = c.String(maxLength: 512, unicode: false),
                        Order = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeason)
                .ForeignKey("SeasonStatus", t => t.IdSeasonStatus)
                .ForeignKey("User", t => t.IdUser)
                .ForeignKey("Visibility", t => t.IdVisibility)
                .ForeignKey("Product", t => t.IdProduct);
            
            CreateTable(
                "SeasonStatus",
                c => new
                    {
                        IdSeasonStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeasonStatus);
            
            CreateTable(
                "User",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        IdProfile = c.Int(nullable: false),
                        IdUserStatus = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("Profile", t => t.IdProfile)
                .ForeignKey("UserStatus", t => t.IdUserStatus);
            
            CreateTable(
                "PasswordHistory",
                c => new
                    {
                        IdPasswordHistory = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 256, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPasswordHistory)
                .ForeignKey("User", t => t.IdUser);
            
            CreateTable(
                "Profile",
                c => new
                    {
                        IdProfile = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 64, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProfile);
            
            CreateTable(
                "ProfilePermission",
                c => new
                    {
                        IdProfile = c.Int(nullable: false),
                        IdPermission = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdProfile, t.IdPermission })
                .ForeignKey("Permission", t => t.IdPermission)
                .ForeignKey("Profile", t => t.IdProfile);
            
            CreateTable(
                "Permission",
                c => new
                    {
                        IdPermission = c.Int(nullable: false),
                        IdPermissionType = c.Int(nullable: false),
                        IdPermissionGroup = c.Int(nullable: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPermission)
                .ForeignKey("PermissionGroup", t => t.IdPermissionGroup)
                .ForeignKey("PermissionType", t => t.IdPermissionType);
            
            CreateTable(
                "PermissionGroup",
                c => new
                    {
                        IdPermissionGroup = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPermissionGroup);
            
            CreateTable(
                "PermissionType",
                c => new
                    {
                        IdPermissionType = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdPermissionType);
            
            CreateTable(
                "TokenProvider",
                c => new
                    {
                        IdTokenProvider = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(),
                        IdTokenProviderType = c.Int(nullable: false),
                        Token = c.String(nullable: false, maxLength: 512, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        UpdatedAt = c.DateTime(nullable: false, precision: 0),
                        Valid = c.Boolean(nullable: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTokenProvider)
                .ForeignKey("TokenProviderType", t => t.IdTokenProviderType)
                .ForeignKey("User", t => t.IdUser);
            
            CreateTable(
                "TokenProviderType",
                c => new
                    {
                        IdTokenProviderType = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 64, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                        HoursValid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTokenProviderType);
            
            CreateTable(
                "UserInfo",
                c => new
                    {
                        IdUser = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 64, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 128, unicode: false),
                        Email = c.String(nullable: false, maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        SecurityStamp = c.String(nullable: false, maxLength: 256, unicode: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        UserName = c.String(nullable: false, maxLength: 32, unicode: false),
                        PasswordHash = c.String(nullable: false, maxLength: 256, unicode: false),
                        AccessFaliedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("User", t => t.IdUser);
            
            CreateTable(
                "UserStatus",
                c => new
                    {
                        IdUserStatus = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 32, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdUserStatus);
            
            CreateTable(
                "Visibility",
                c => new
                    {
                        IdVisibility = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 64, unicode: false),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdVisibility);
            
            CreateTable(
                "LogEvent",
                c => new
                    {
                        IdEvent = c.Int(nullable: false, identity: true),
                        Exception = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Level = c.String(nullable: false, maxLength: 50, unicode: false),
                        Logger = c.String(nullable: false, maxLength: 255, unicode: false),
                        Message = c.String(nullable: false, maxLength: 4000, unicode: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 0),
                        Excluded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdEvent);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Episode", "IdVisibility", "Visibility");
            DropForeignKey("Episode", "IdUser", "User");
            DropForeignKey("Episode", "IdSeason", "Season");
            DropForeignKey("Episode", "IdProduct", "Product");
            DropForeignKey("Product", "IdVisibility", "Visibility");
            DropForeignKey("Product", "IdUser", "User");
            DropForeignKey("Season", "IdProduct", "Product");
            DropForeignKey("Season", "IdVisibility", "Visibility");
            DropForeignKey("Season", "IdUser", "User");
            DropForeignKey("User", "IdUserStatus", "UserStatus");
            DropForeignKey("UserInfo", "IdUser", "User");
            DropForeignKey("TokenProvider", "IdUser", "User");
            DropForeignKey("TokenProvider", "IdTokenProviderType", "TokenProviderType");
            DropForeignKey("User", "IdProfile", "Profile");
            DropForeignKey("ProfilePermission", "IdProfile", "Profile");
            DropForeignKey("ProfilePermission", "IdPermission", "Permission");
            DropForeignKey("Permission", "IdPermissionType", "PermissionType");
            DropForeignKey("Permission", "IdPermissionGroup", "PermissionGroup");
            DropForeignKey("PasswordHistory", "IdUser", "User");
            DropForeignKey("Season", "IdSeasonStatus", "SeasonStatus");
            DropForeignKey("Product", "IdProductType", "ProductType");
            DropForeignKey("Product", "IdProductStatus", "ProductStatus");
            DropForeignKey("ProductInfo", "IdProduct", "Product");
            DropForeignKey("ProductProductCategory", "IdProduct", "Product");
            DropForeignKey("ProductProductCategory", "IdCategory", "ProductCategory");
            DropForeignKey("Episode", "IdEpisodeStatus", "EpisodeStatus");
            DropTable("LogEvent");
            DropTable("Visibility");
            DropTable("UserStatus");
            DropTable("UserInfo");
            DropTable("TokenProviderType");
            DropTable("TokenProvider");
            DropTable("PermissionType");
            DropTable("PermissionGroup");
            DropTable("Permission");
            DropTable("ProfilePermission");
            DropTable("Profile");
            DropTable("PasswordHistory");
            DropTable("User");
            DropTable("SeasonStatus");
            DropTable("Season");
            DropTable("ProductType");
            DropTable("ProductStatus");
            DropTable("ProductInfo");
            DropTable("ProductCategory");
            DropTable("ProductProductCategory");
            DropTable("Product");
            DropTable("EpisodeStatus");
            DropTable("Episode");
            DropTable("Configuration");
        }
    }
}
