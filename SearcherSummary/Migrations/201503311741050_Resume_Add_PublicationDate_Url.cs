namespace SearcherSummary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resume_Add_PublicationDate_Url : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "PublicationDate", c => c.DateTime());
            AddColumn("dbo.Resumes", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "Url");
            DropColumn("dbo.Resumes", "PublicationDate");
        }
    }
}
