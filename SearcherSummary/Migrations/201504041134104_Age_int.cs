namespace SearcherSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Age_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Age", c => c.String());
        }
    }
}
