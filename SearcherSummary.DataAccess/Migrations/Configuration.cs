using System.Data.Entity.Migrations;
using SearcherSummary.DataAccess.DataAccess;

namespace SearcherSummary.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SearcherSummaryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SearcherSummary.DataAccess.SearcherSummaryContext";
        }

        protected override void Seed(SearcherSummaryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
