using Microsoft.Win32;
using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    class MainWindowViewModel:NotificationObject
    {
        public MainWindowViewModel()
        {
            AddCommand=new DelegateCommand();
            AddCommand.ExecuteAction += Add;
            SaveCommand = new DelegateCommand();
            SaveCommand.ExecuteAction += Save;
        }

        private double _input1;

        public double Input1
        {
            get { return _input1; }
            set
            {
                _input1 = value;
                this.RaisePropertyChanged("Input1");
            }
        }

        private double _input2;

        public double Input2
        {
            get { return _input2; }
            set
            {
                _input2 = value;
                this.RaisePropertyChanged("Input2");
            }
        }

        private double _result;

        public double Result
        {
            get { return _result; }
            set
            {
                _result = value;
                this.RaisePropertyChanged("Result");
            }
        }

        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        private void Add(object parameter)
        {
            Result = Input1 + Input2;
        }

        private void Save(object parameter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
        }
    }
}
