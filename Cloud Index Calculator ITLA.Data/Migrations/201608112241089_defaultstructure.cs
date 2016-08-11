namespace Cloud_Index_Calculator_ITLA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defaultstructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Careers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quarters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Selections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification_Id = c.Int(),
                        Subject_Id = c.Int(),
                        Quarter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Qualifications", t => t.Qualification_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Quarters", t => t.Quarter_Id)
                .Index(t => t.Qualification_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Quarter_Id);
            
            CreateTable(
                "dbo.SubjectCareers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Career_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Career_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Careers", t => t.Career_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Career_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selections", "Quarter_Id", "dbo.Quarters");
            DropForeignKey("dbo.Selections", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Selections", "Qualification_Id", "dbo.Qualifications");
            DropForeignKey("dbo.SubjectCareers", "Career_Id", "dbo.Careers");
            DropForeignKey("dbo.SubjectCareers", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.SubjectCareers", new[] { "Career_Id" });
            DropIndex("dbo.SubjectCareers", new[] { "Subject_Id" });
            DropIndex("dbo.Selections", new[] { "Quarter_Id" });
            DropIndex("dbo.Selections", new[] { "Subject_Id" });
            DropIndex("dbo.Selections", new[] { "Qualification_Id" });
            DropTable("dbo.SubjectCareers");
            DropTable("dbo.Selections");
            DropTable("dbo.Quarters");
            DropTable("dbo.Qualifications");
            DropTable("dbo.Subjects");
            DropTable("dbo.Careers");
        }
    }
}
