using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GamingDnV.ViewModels
{
    public class LoaderViewModel : ViewModelBase
    {
        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;

                RaisePropertyChanged(nameof(Progress));
            }
        }
        private Visibility _loaderVisibility;
        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;

                RaisePropertyChanged(nameof(LoaderVisibility));
            }
        }
        public LoaderViewModel()
        {
            LoaderVisibility = Visibility.Hidden;
            Progress = 0;
        }

        public void ProgressView(double n, double d)
        {
            double prog = (616 / d) * n;
            Progress = Convert.ToInt32(Math.Round(prog));
        }
    }
}
