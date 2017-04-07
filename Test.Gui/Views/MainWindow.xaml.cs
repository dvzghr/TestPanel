using System;
using System.Collections.Generic;
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

namespace Test.Gui.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        //hack: http://stackoverflow.com/questions/3621424/page-datacontext-not-inherited-from-parent-frame
        private void MainFrame_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UpdateContext(sender as Frame);
        }

        private void MainFrame_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            UpdateContext(sender as Frame);
        }

        private void UpdateContext(Frame frame)
        {
            var page = frame.Content as Page;
            if (page != null)
                page.DataContext = this.DataContext;
        }
    }
}