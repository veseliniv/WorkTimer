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
    public class ProjectDataPersister
    {
        internal static IEnumerable<ProjectViewModel> GetAllProjects()
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            var allProjects =
                (from ap in entity.Projects
                 select new ProjectViewModel()
                 {
                     ID = ap.ID,
                     Name = ap.Name
                 }).ToList();

            return allProjects;
        }

        internal static void AddNewProject(ProjectViewModel project)
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            if(!ProjectExists(project))
            {
                entity.Projects.Add(new Project()
                {
                    Name = project.Name
                });
            }

            entity.SaveChanges();
            MessageBox.Show("Project Added","Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        internal static int GetProjectID(string projectName)
        {
            WorkTimerDBEntities entity = new WorkTimerDBEntities();

            var projectID =
                (from pi in entity.Projects
                 where pi.Name == projectName
                 select pi.ID).First();

            return projectID;
        }
        internal static bool ProjectExists(ProjectViewModel project)
        {
            bool projectExists = false;

            IEnumerable<ProjectViewModel> allProjects = GetAllProjects();

            foreach (ProjectViewModel projectToCompare in allProjects)
            {
                if (projectToCompare.Name == project.Name)
                {
                    projectExists = true;
                    MessageBox.Show("This project already exists", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
            return projectExists;
        }
    }
}
