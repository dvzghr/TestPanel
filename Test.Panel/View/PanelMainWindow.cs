using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using Test.Services.Interface;

namespace Test.Panel.View
{
    public abstract class PanelMainWindow : Window
    {
        protected IInactivityTrackerService InactivityTrackerService;

        protected PanelMainWindow()
        {
            InactivityTrackerService = SimpleIoc.Default.GetInstance<IInactivityTrackerService>();

            SetupInactivity();
        }

        private void SetupInactivity()
        {
            PreviewKeyDown += RestartTimer;
            PreviewMouseDown += RestartTimer;
        }

        private void RestartTimer(object sender, EventArgs e)
        {
            if(InactivityTrackerService.IsActive)
                InactivityTrackerService.Restart();
        }
    }
}
