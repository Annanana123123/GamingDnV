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
using System.Windows.Shapes;
using GamingDnV.ViewModels;

namespace GamingDnV.Views
{
    /// <summary>
    /// Логика взаимодействия для PreView.xaml
    /// </summary>
    public partial class PreView : Window
    {
        //PreViewModel vm = new PreViewModel();
        public PreView(PreViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
