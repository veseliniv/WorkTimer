using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTimer.Views;

namespace WorkTimer.DataPersisters
{
    public class ViewsDataPersister
    {
        internal static ChooseProjectWindow chooseProjectWindow = new ChooseProjectWindow();

        internal static AddNewProjectWindow addNewProjectWindow = new AddNewProjectWindow();

        internal static ResultWindow resultWindow = new ResultWindow();

        internal static ShowTimesWindow showTimesWindow = new ShowTimesWindow();

        internal static MainWindow mainWindow = new MainWindow();
    }
}
