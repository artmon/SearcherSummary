namespace SearcherSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Birthday");
        }
    }
}
