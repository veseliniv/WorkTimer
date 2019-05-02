using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorkTimer.DataPersisters;
using WorkTimer.ViewModels;

namespace WorkTimer.Views
{
    /// <summary>
    /// Interaction logic for ChooseProjectWindow.xaml
    /// </summary>
    public partial class ChooseProjectWindow : Window
    {
       

        public ChooseProjectWindow()
        {
            InitializeComponent();
            //labelTimeElapsed.Content = "00:00:00";
            
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            labelTimeElapsed.Content = "00:00:00";
           
        }

        private void WindowClosed(object sender, EventArgs e)
        {
           Application.Current.Shutdown();
        }
    }
}
