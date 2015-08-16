using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using SearcherSummary.Infrastructure;

namespace SearcherSummary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceLocatorManagement.Init();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (ServiceLocatorManagement.WindsorContainer != null)
            {
                ServiceLocatorManagement.WindsorContainer.Dispose();
            }
        }
    }
}
