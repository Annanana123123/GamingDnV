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

namespace GamingDnV
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowsViewModel vm = new MainWindowsViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            this.Loaded += OnLoad;
        }
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowsViewModel).OnLoad();
        }

        private void GridUser_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.Update(sender, e);
        }

        private void GridNPC_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            vm.Update(sender, e);
        }
    }
}
