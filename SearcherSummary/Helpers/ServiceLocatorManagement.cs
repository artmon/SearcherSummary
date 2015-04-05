using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Microsoft.Practices.ServiceLocation;

namespace SearcherSummary.Helpers
{
    public static class ServiceLocatorManagement
    {
        public static IWindsorContainer WindsorContainer { get; private set; }

        public static void Init()
        {
            WindsorContainer = new WindsorContainer();
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(WindsorContainer));
        }
    }
}
