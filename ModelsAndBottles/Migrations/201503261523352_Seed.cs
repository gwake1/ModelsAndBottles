namespace ModelsAndBottles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Terroirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(nullable: false),
                        Region = c.String(nullable: false),
                        Appelation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
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
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VintageMaturities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaturityDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WineLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WineListId = c.Int(nullable: false),
                        TerroirId = c.Int(nullable: false),
                        WineVintageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Terroirs", t => t.TerroirId, cascadeDelete: false)
                .ForeignKey("dbo.WineLists", t => t.WineListId, cascadeDelete: false)
                .Index(t => t.WineListId)
                .Index(t => t.TerroirId);
            
            CreateTable(
                "dbo.WineVintages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VintageYear = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        VintageMaturityId = c.Int(nullable: false),
                        WineId = c.Int(nullable: false),
                        WineListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VintageMaturities", t => t.VintageMaturityId, cascadeDelete: false)
                .ForeignKey("dbo.Wines", t => t.WineId, cascadeDelete: false)
                .ForeignKey("dbo.WineLists", t => t.WineListId, cascadeDelete: false)
                .Index(t => t.VintageMaturityId)
                .Index(t => t.WineId)
                .Index(t => t.WineListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WineVintages", "WineListId", "dbo.WineLists");
            DropForeignKey("dbo.WineVintages", "WineId", "dbo.Wines");
            DropForeignKey("dbo.WineVintages", "VintageMaturityId", "dbo.VintageMaturities");
            DropForeignKey("dbo.Wines", "WineListId", "dbo.WineLists");
            DropForeignKey("dbo.Wines", "TerroirId", "dbo.Terroirs");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.WineVintages", new[] { "WineListId" });
            DropIndex("dbo.WineVintages", new[] { "WineId" });
            DropIndex("dbo.WineVintages", new[] { "VintageMaturityId" });
            DropIndex("dbo.Wines", new[] { "TerroirId" });
            DropIndex("dbo.Wines", new[] { "WineListId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.WineVintages");
            DropTable("dbo.Wines");
            DropTable("dbo.WineLists");
            DropTable("dbo.VintageMaturities");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Terroirs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
