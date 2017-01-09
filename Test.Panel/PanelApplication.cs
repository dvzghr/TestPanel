using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Test.Services;
using Test.Services.Interface;

namespace Test.Panel
{
    public abstract class PanelApplication : Application
    {
        protected PanelApplication()
        {
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SetupServices();
        }

        private void SetupServices()
        {
            //SimpleIoc.Default.Register<IPeopleService, PeopleService>();

            SimpleIoc.Default.Register<IInactivityTrackerService, InactivityTrackerService>();
        }
    }
}
