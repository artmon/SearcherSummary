using System.Data.Entity.Migrations;

namespace SearcherSummary.DataAccess.Migrations
{
    public partial class Add_AddDate_And_ModDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "AddDate", c => c.DateTime());
            AddColumn("dbo.Resumes", "ModDate", c => c.DateTime());
            DropColumn("dbo.Resumes", "PublicationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resumes", "PublicationDate", c => c.DateTime());
            DropColumn("dbo.Resumes", "ModDate");
            DropColumn("dbo.Resumes", "AddDate");
        }
    }
}
