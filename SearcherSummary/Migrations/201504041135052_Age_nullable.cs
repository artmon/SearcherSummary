namespace SearcherSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Age_nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Age", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Age", c => c.Int(nullable: false));
        }
    }
}
