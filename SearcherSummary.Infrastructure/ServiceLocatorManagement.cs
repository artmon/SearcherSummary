using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;
using SearcherSummary.BusinessLogic.Contracts;
using SearcherSummary.DataAccess.Contracts;

namespace SearcherSummary.Infrastructure
{
    public static class ServiceLocatorManagement
    {
        public static IWindsorContainer WindsorContainer { get; private set; }

        public static void Init()
        {
            WindsorContainer = new WindsorContainer();
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(WindsorContainer));
            AddServices();
        }

        public static void Dispose()
        {
            if (WindsorContainer != null)
            {
                WindsorContainer.Dispose();
            }
        }

        private static void AddServices()
        {
            WindsorContainer.Register(
                Classes
                    .FromAssembly(typeof(IDataAccessService).Assembly)
                    .Pick().WithService.AllInterfaces());

            WindsorContainer.Register(
                Classes
                    .FromAssembly(typeof (ISearchService).Assembly)
                    .Pick().WithService.AllInterfaces());
        }

    }
}
