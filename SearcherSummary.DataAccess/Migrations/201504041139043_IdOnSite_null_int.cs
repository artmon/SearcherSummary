using System.Data.Entity.Migrations;

namespace SearcherSummary.DataAccess.Migrations
{
    public partial class IdOnSite_null_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resumes", "IdOnSite", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resumes", "IdOnSite", c => c.String());
        }
    }
}
