using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Test.Gui.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INavigationService
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.Register<INavigationService>(() => this);

            Debug.Assert(NavigationService != null, "NavigationService != null");
            NavigationService.Navigating += OnNavigated;
        }

        private void OnNavigated(object sender, NavigatingCancelEventArgs navigatingCancelEventArgs)
        {
            Debug.Assert(NavigationService != null, "NavigationService != null");
            NavigationService.Navigating -= OnNavigated;
            SimpleIoc.Default.Unregister<INavigationService>();
        }

        public void GoBack()
        {
            Debug.Assert(NavigationService != null, "NavigationService != null");
            NavigationService.GoBack();
        }

        public void NavigateTo(string pageKey)
        {
            Debug.Assert(NavigationService != null, "NavigationService != null");
            NavigationService.Navigate(new Uri($"../Views/{pageKey}.xaml", UriKind.Relative));
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            Debug.Assert(NavigationService != null, "NavigationService != null");
            NavigationService.Navigate(pageKey, parameter);
        }

        public string CurrentPageKey { get; }
    }
}
