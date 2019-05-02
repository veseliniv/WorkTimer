using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkTimer.DataPersisters;
using WorkTimer.ViewModels;

namespace WorkTimer.HelperClasses
{
    public class PopulateUtil
    {
        internal static void PopulateChooseProjectWindow(string projectName, string taskName, TaskViewModel task)
        {
            ViewsDataPersister.chooseProjectWindow.dataGridTimes.ItemsSource = WorkTimeDataPersister.GetAllTimesByProject(projectName);
            if (!WorkTaskDataPersister.TaskExists(taskName, projectName))
            {
                WorkTaskDataPersister.AddTask(task, ProjectDataPersister.GetProjectID(projectName), projectName);
            }
            ViewsDataPersister.chooseProjectWindow.labelTaskName.Content = taskName;
            ViewsDataPersister.chooseProjectWindow.labelNewProjectName.Content = projectName;
            ViewsDataPersister.chooseProjectWindow.Title = projectName;

            NavigationUtil.OpenChooseProjectWindow();
        }
    }
}
