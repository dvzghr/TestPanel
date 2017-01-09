using System.Windows.Documents;
using GalaSoft.MvvmLight;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Test.Services.Interface;

namespace Test.Gui.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //GetPeople();
            Task.Run(async () => await GetPeople());
        }

        private IPeopleService peopleService = SimpleIoc.Default.GetInstance<IPeopleService>();

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (Set(() => Name, ref _name, value))
                    RaisePropertyChanged();
            }
        }

        private List<string> _names;

        public List<string> Names
        {
            get { return _names; }
            set
            {
                if (_names == value) return;
                _names = value;
                RaisePropertyChanged();
            }
        }

        private async Task GetPeople()
        {
            Names = new List<string> { "Fetching", "new people...", "please", "stand by..." };
            Names = await peopleService.GetAll();
        }

    }
}