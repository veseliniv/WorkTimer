using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkTimer.DataPersisters;

namespace WorkTimer.HelperClasses
{
    public class NavigationUtil
    {
        internal static void OpenChooseProjectWindow()
        {
            ViewsDataPersister.chooseProjectWindow.Show();

            Application.Current.MainWindow.Close();
        }

        internal static void OpenAddNewProjectWindow()
        {
            ViewsDataPersister.addNewProjectWindow.Show();

            Application.Current.MainWindow.Close();
        }

        internal static void CloseAddNewProjectWindow()
        {
            ViewsDataPersister.mainWindow.Show();

            ViewsDataPersister.addNewProjectWindow.Close();
        }
    }
}
