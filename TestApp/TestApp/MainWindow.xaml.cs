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
using TestApp.ViewModels;

namespace TestApp
{
    public partial class MainWindow : Window
    {
        MainViewModel mainV = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainV;
        }
    }
}
