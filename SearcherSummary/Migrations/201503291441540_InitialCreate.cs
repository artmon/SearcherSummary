namespace SearcherSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationalInstitutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Name = c.String(),
                        City = c.String(),
                        Form = c.String(),
                        Education_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.Education_Id)
                .Index(t => t.Education_Id);
            
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeWork = c.String(),
                        ExperienceLength = c.String(),
                        Resume_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resumes", t => t.Resume_Id)
                .Index(t => t.Resume_Id);
            
            CreateTable(
                "dbo.WorkPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeWork = c.String(),
                        OrganizationName = c.String(),
                        Position = c.String(),
                        Info = c.String(),
                        Experience_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experiences", t => t.Experience_Id)
                .Index(t => t.Experience_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fio = c.String(),
                        Age = c.String(),
                        PersonalInfo = c.String(),
                        Locations = c.String(),
                        Contacts = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        IdOnSite = c.String(),
                        ResumeInfo = c.String(),
                        Title = c.String(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        WorkType = c.String(),
                        Skills = c.String(),
                        AdditionalInfo = c.String(),
                        MayMove = c.Boolean(),
                        Education_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Educations", t => t.Education_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Education_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Experiences", "Resume_Id", "dbo.Resumes");
            DropForeignKey("dbo.Resumes", "Education_Id", "dbo.Educations");
            DropForeignKey("dbo.WorkPlaces", "Experience_Id", "dbo.Experiences");
            DropForeignKey("dbo.EducationalInstitutions", "Education_Id", "dbo.Educations");
            DropIndex("dbo.Resumes", new[] { "Person_Id" });
            DropIndex("dbo.Resumes", new[] { "Education_Id" });
            DropIndex("dbo.WorkPlaces", new[] { "Experience_Id" });
            DropIndex("dbo.Experiences", new[] { "Resume_Id" });
            DropIndex("dbo.EducationalInstitutions", new[] { "Education_Id" });
            DropTable("dbo.Resumes");
            DropTable("dbo.People");
            DropTable("dbo.WorkPlaces");
            DropTable("dbo.Experiences");
            DropTable("dbo.Educations");
            DropTable("dbo.EducationalInstitutions");
        }
    }
}
