using System.Data.Entity.Migrations;

namespace SearcherSummary.DataAccess.Migrations
{
    public partial class Experience_not_List : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Experiences", "Resume_Id", "dbo.Resumes");
            DropIndex("dbo.Experiences", new[] { "Resume_Id" });
            AddColumn("dbo.Resumes", "Experience_Id", c => c.Int());
            CreateIndex("dbo.Resumes", "Experience_Id");
            AddForeignKey("dbo.Resumes", "Experience_Id", "dbo.Experiences", "Id");
            DropColumn("dbo.Experiences", "Resume_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiences", "Resume_Id", c => c.Int());
            DropForeignKey("dbo.Resumes", "Experience_Id", "dbo.Experiences");
            DropIndex("dbo.Resumes", new[] { "Experience_Id" });
            DropColumn("dbo.Resumes", "Experience_Id");
            CreateIndex("dbo.Experiences", "Resume_Id");
            AddForeignKey("dbo.Experiences", "Resume_Id", "dbo.Resumes", "Id");
        }
    }
}
