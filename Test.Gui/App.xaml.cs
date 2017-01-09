using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Test.Gui.View;
using Test.Gui.ViewModel;
using Test.Panel;

namespace Test.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PanelApplication
    {
        public App()
        {
            Startup += App_Startup;
            Exit += OnExit;
            DispatcherUnhandledException += App_DispatcherUnhandledException;

            //SimpleIoc.Default.Register<ViewModelLocator>();
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            //var locator = ServiceLocator.Current.GetInstance<ViewModelLocator>();
            //var mainWindow = new MainWindow { DataContext = locator };
            //var mainWindow = new TestWindow { DataContext = locator };
            //mainWindow.Show();
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnExit(object sender, ExitEventArgs exitEventArgs)
        {

        }
    }
}
