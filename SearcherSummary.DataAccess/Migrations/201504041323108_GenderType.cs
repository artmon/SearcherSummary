using System.Data.Entity.Migrations;

namespace SearcherSummary.DataAccess.Migrations
{
    public partial class GenderType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "GenderType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "GenderType");
        }
    }
}
