using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMExercise.View;
using System.Collections.Generic;

namespace MVVMExercise.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Modules = new List<Module>();
            Modules.Add(new Module() { Name = "Module1" });
            Modules.Add(new Module() { Name = "Module2" });
            Modules.Add(new Module() { Name = "Module3" });
            OpenCommand = new RelayCommand<string>(OpenPage);
        }
        public List<Module> Modules { get; set; }

        private object _page;
        public object Page
        {
            get { return _page; }
            set
            {
                _page = value;
                this.RaisePropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public RelayCommand<string> OpenCommand { get; set; }


        public void OpenPage(string name)
        {
            Name = name;
            switch (name)
            {
                case "Module1":
                    Page = new Page1();
                    break;
                case "Module2":
                    Page = new Page2();
                    break;
                case "Module3":
                    Page = new Page3();
                    break;
                default:
                    break;
            }
        }
    }
}