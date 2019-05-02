using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkTimer.DAL;
using WorkTimer.ViewModels;
using WorkTimer.Views;

namespace WorkTimer.DataPersisters
{
    public class WorkTimeDataPersister
    {
        internal static IEnumerable<TimeViewModel> GetAllTimes()
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            var allTimes =
                 (from at in entity.Times
                 select new TimeViewModel()
                 {
                     Time = at.Time1,
                     Task = new TaskViewModel()
                     {
                         Name = at.Task.Name,
                         Project = new ProjectViewModel()
                         {
                             Name = at.Task.Project.Name
                         }

                     }
                 }).ToList();

            return allTimes;
        }

        internal static IEnumerable<TimeViewModel> GetAllTimesByProject(string projectName)
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            var timesByProject =
                (from tbp in entity.Times
                 where tbp.Task.Project.Name == projectName
                 select new TimeViewModel()
                 {
                     Time = tbp.Time1,
                     Task = new TaskViewModel()
                     {
                         Name = tbp.Task.Name,
                         Project = new ProjectViewModel()
                         {
                             Name = tbp.Task.Project.Name
                         }

                     }
                 }).ToList();
            
            return timesByProject;
        }

        internal static void AddTime(DateTime time, int taskID)
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            try
            {
                entity.Times.Add(new DAL.Time()
                {
                    Time1 = time,
                    TaskID = taskID
                });

                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
