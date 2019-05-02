using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkTimer.DAL;
using WorkTimer.ViewModels;

namespace WorkTimer.DataPersisters
{
    public class WorkTaskDataPersister
    {
        internal static IEnumerable<TaskViewModel> GetAllTasks()
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            var allTasks =
                (from at in entity.Tasks
                 select  new TaskViewModel()
                 {
                     ID = at.ID,
                     Name = at.Name,
                     Project = new ProjectViewModel()
                     {
                         Name=at.Project.Name
                     }
                 }).ToList();

            return allTasks;
        }
        internal static void AddTask(TaskViewModel task, int projectID, string projectName)
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            if (!TaskExists(task.Name, projectName))
            {

                entity.Tasks.Add(new DAL.Task()
                {
                    Name = task.Name,
                    ProjectID = projectID
                });
            }

            entity.SaveChanges();
        }

        internal static int GetTaskID(string taskName)
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            var taskID =
                (from ti in entity.Tasks
                 where ti.Name == taskName
                 select ti.ID).First();

            return taskID;
        }

        internal static bool TaskExists(string taskName, string projectName)
        {
            bool taskExists = false;

            IEnumerable<TaskViewModel> allTasks = GetAllTasks();

            foreach (TaskViewModel taskToCompare in allTasks)
            {
                if (taskToCompare.Name == taskName && taskToCompare.Project.Name == projectName)
                {
                    taskExists = true;
                    MessageBox.Show("This task already exists", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
            return taskExists;
        }
    }
}
