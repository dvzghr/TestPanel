/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Test.Gui"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using Test.Services;
using Test.Services.Interface;
using System;
using System.Diagnostics;

namespace Test.Gui.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private INavigationService _navigationService;

        public RelayCommand<string> NavigateCommand { get; set; }


        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            Debug.WriteLine("Locator created!");

            //Register Services
            if (!ServiceLocator.IsLocationProviderSet)
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IPeopleService, MockPeopleService>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IPeopleService, PeopleService>();
            }
            
            SimpleIoc.Default.Register<MainViewModel>();

            //Setup commands
            NavigateCommand = new RelayCommand<string>(OnNavigate);

        }

        public string Name => "Locator";

        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        private void OnNavigate(string page)
        {
            Debug.WriteLine("Get NavigationService!");
            _navigationService = SimpleIoc.Default.GetInstance<INavigationService>();
            _navigationService.NavigateTo(page);
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}