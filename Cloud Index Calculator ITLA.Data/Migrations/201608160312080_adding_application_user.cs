namespace Cloud_Index_Calculator_ITLA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_application_user : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Selections", "Quarter_Id", "dbo.Quarters");
            DropForeignKey("dbo.Selections", "Qualification_Id", "dbo.Qualifications");
            DropForeignKey("dbo.Selections", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Selections", new[] { "Qualification_Id" });
            DropIndex("dbo.Selections", new[] { "Subject_Id" });
            DropIndex("dbo.Selections", new[] { "Quarter_Id" });
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Users",
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
                "dbo.Claims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            AddColumn("dbo.Selections", "Qualification_Id1", c => c.Int());
            AddColumn("dbo.Selections", "Subject_Id1", c => c.Int());
            AddColumn("dbo.Selections", "Quarter_Id1", c => c.Int());
            AlterColumn("dbo.Selections", "Qualification_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Selections", "Subject_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Selections", "Quarter_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Selections", "Qualification_Id1");
            CreateIndex("dbo.Selections", "Subject_Id1");
            CreateIndex("dbo.Selections", "Quarter_Id1");
            AddForeignKey("dbo.Selections", "Quarter_Id1", "dbo.Quarters", "Id");
            AddForeignKey("dbo.Selections", "Qualification_Id1", "dbo.Qualifications", "Id");
            AddForeignKey("dbo.Selections", "Subject_Id1", "dbo.Subjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selections", "Subject_Id1", "dbo.Subjects");
            DropForeignKey("dbo.Selections", "Qualification_Id1", "dbo.Qualifications");
            DropForeignKey("dbo.Selections", "Quarter_Id1", "dbo.Quarters");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.Logins", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.Claims", "IdentityUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.Logins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Claims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Selections", new[] { "Quarter_Id1" });
            DropIndex("dbo.Selections", new[] { "Subject_Id1" });
            DropIndex("dbo.Selections", new[] { "Qualification_Id1" });
            AlterColumn("dbo.Selections", "Quarter_Id", c => c.Int());
            AlterColumn("dbo.Selections", "Subject_Id", c => c.Int());
            AlterColumn("dbo.Selections", "Qualification_Id", c => c.Int());
            DropColumn("dbo.Selections", "Quarter_Id1");
            DropColumn("dbo.Selections", "Subject_Id1");
            DropColumn("dbo.Selections", "Qualification_Id1");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            CreateIndex("dbo.Selections", "Quarter_Id");
            CreateIndex("dbo.Selections", "Subject_Id");
            CreateIndex("dbo.Selections", "Qualification_Id");
            AddForeignKey("dbo.Selections", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Selections", "Qualification_Id", "dbo.Qualifications", "Id");
            AddForeignKey("dbo.Selections", "Quarter_Id", "dbo.Quarters", "Id");
        }
    }
}
