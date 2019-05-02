using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WorkTimer.Commands;
using WorkTimer.DataPersisters;
using WorkTimer.HelperClasses;
using WorkTimer.Views;

namespace WorkTimer.ViewModels
{
    public class WorkTimerViewModel : BaseViewModel
    {
        private ObservableCollection<TimeViewModel> timeViewModels;
        private TimeViewModel newTimeViewModel;

        private ObservableCollection<TaskViewModel> taskViewModels;
        private TaskViewModel newTaskViewModel;

        private ObservableCollection<ProjectViewModel> projectViewModels;
        private ProjectViewModel newProjectViewModel;

        private ICommand getTimesByProjectCommand;
        private ICommand startTimerCommand;
        private ICommand stopTimerCommand;
        private ICommand restartTimerCommand;
        private ICommand pauseTimerCommand;
        private ICommand saveTimerCommand;
        private ICommand openNewProjectWindowCommand;
        private ICommand addNewProjectCommand;
        private ICommand exportToWordCommand;
        private ICommand exportToExcelCommand;
        private ICommand exportToTXTCommand;

        public WorkTimerViewModel()
        {
            newTimeViewModel = new TimeViewModel();
            newTaskViewModel = new TaskViewModel();
            newProjectViewModel = new ProjectViewModel();
        }

        public IEnumerable<TimeViewModel> Times
        {
            get
            {
                if (newTimeViewModel.Task == null && newTimeViewModel.Time == null)
                {
                    Times = WorkTimeDataPersister.GetAllTimes();
                }

                return timeViewModels;
            }
            set
            {
                if (newTimeViewModel.Task == null && newTimeViewModel.Time == null)
                {
                    timeViewModels = new ObservableCollection<TimeViewModel>();
                }
                timeViewModels.Clear();
                foreach (var time in value)
                {
                    timeViewModels.Add(time);
                }
                OnPropertyChanged("TimesAdded");
            }
        }

        //public IEnumerable<TaskViewModel> Tasks
        //{
        //    get
        //    {
        //        if (newTaskViewModel.Name == null && newTaskViewModel.Project == null)
        //        {
        //            Tasks = WorkTaskDataPersister.GetAllTasks();
        //        }

        //        return taskViewModels;
        //    }
        //    set
        //    {
        //        if (newTaskViewModel.Name == null && newTaskViewModel.Project == null)
        //        {
        //            taskViewModels = new ObservableCollection<TaskViewModel>();
        //        }
        //        taskViewModels.Clear();
        //        foreach (var task in value)
        //        {
        //            taskViewModels.Add(task);
        //        }
        //    }
        //}

        public IEnumerable<ProjectViewModel> Projects
        {
            get
            {
                if (newProjectViewModel.Name == null)
                {
                    Projects = ProjectDataPersister.GetAllProjects();
                }
                return projectViewModels;
            }
            set
            {
                if (newProjectViewModel.Name == null)
                {
                    projectViewModels = new ObservableCollection<ProjectViewModel>();
                }
                projectViewModels.Clear();
                foreach (var project in value)
                {
                    projectViewModels.Add(project);
                }
            }
        }

        public IEnumerable<TimeViewModel> TimesAdded
        {
            get
            {
                return timeViewModels.ToList();
            }
            set
            {
                if (newTimeViewModel == null)
                {
                    timeViewModels = new ObservableCollection<TimeViewModel>();
                }
                timeViewModels.Clear();
                foreach (var time in value)
                {
                    timeViewModels.Add(time);
                }
                OnPropertyChanged("TimesAdded");
            }
        }

        public TimeViewModel NewTime
        {
            get
            {
                return newTimeViewModel;
            }
            set
            {
                newTimeViewModel = value;
            }
        }

        public TaskViewModel NewTask
        {
            get
            {
                return newTaskViewModel;
            }
            set
            {
                newTaskViewModel = value;
            }
        }

        public ProjectViewModel NewProject
        {
            get
            {
                return newProjectViewModel;
            }
            set
            {
                newProjectViewModel = value;
            }
        }

        public ICommand GetTimesByProject
        {
            get
            {
                if (getTimesByProjectCommand == null)
                {
                    getTimesByProjectCommand = new RelayCommand(HandleGetTimesByProjectCommand);
                }

                return getTimesByProjectCommand;
            }
        }

        private void HandleGetTimesByProjectCommand(object obj)
        {
            try
            {
                PopulateUtil.PopulateChooseProjectWindow(NewProject.Name, NewTask.Name, NewTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand StartTimerCommand
        {
            get
            {
                if (startTimerCommand == null)
                {
                    startTimerCommand = new RelayCommand(HandleStartTimerCommand);
                }

                return startTimerCommand;
            }
        }

        private void HandleStartTimerCommand(object obj)
        {
            try
            {
                StopwatchDataPersister.StartStopwatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand StopTimerCommand
        {
            get
            {
                if (stopTimerCommand == null)
                {
                    stopTimerCommand = new RelayCommand(HandleStopTimerCommand);
                }

                return stopTimerCommand;
            }
        }

        private void HandleStopTimerCommand(object obj)
        {
            try
            {
                StopwatchDataPersister.StopAndResetStopwatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand RestartTimerCommand
        {
            get
            {
                if (restartTimerCommand == null)
                {
                    restartTimerCommand = new RelayCommand(HandleRestartTimerCommand);
                }

                return restartTimerCommand;
            }
        }

        private void HandleRestartTimerCommand(object obj)
        {
            try
            {
                StopwatchDataPersister.RestartStopwatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand PauseTimerCommand
        {
            get
            {
                if (pauseTimerCommand == null)
                {
                    pauseTimerCommand = new RelayCommand(HandlePauseTimerCommand);
                }

                return pauseTimerCommand;
            }
        }

        private void HandlePauseTimerCommand(object obj)
        {
            try
            {
                StopwatchDataPersister.PauseStopwatch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand SaveTimerCommand
        {
            get
            {
                if (saveTimerCommand == null)
                {
                    saveTimerCommand = new RelayCommand(HandleSaveTimerCommand);
                }

                return saveTimerCommand;
            }
        }

        private void HandleSaveTimerCommand(object obj)
        {
            NewTask.Name = ViewsDataPersister.chooseProjectWindow.labelTaskName.Content.ToString();
            NewProject.Name = ViewsDataPersister.chooseProjectWindow.labelNewProjectName.Content.ToString();
            WorkTimeDataPersister.AddTime(StopwatchDataPersister.time, WorkTaskDataPersister.GetTaskID(NewTask.Name));
            ViewsDataPersister.chooseProjectWindow.dataGridTimes.ItemsSource = WorkTimeDataPersister.GetAllTimesByProject(NewProject.Name);
        }

        public ICommand OpenNewProjectWindowCommand
        {
            get
            {
                if (openNewProjectWindowCommand == null)
                {
                    openNewProjectWindowCommand = new RelayCommand(HandleOpenNewProjectWindowCommand);
                }

                return openNewProjectWindowCommand;
            }
        }

        private void HandleOpenNewProjectWindowCommand(object obj)
        {
            try
            {
                NavigationUtil.OpenAddNewProjectWindow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand AddNewProjectCommand
        {
            get
            {
                if (addNewProjectCommand == null)
                {
                    addNewProjectCommand = new RelayCommand(HandleAddNewProjectCommand);
                }

                return addNewProjectCommand;
            }
        }

        private void HandleAddNewProjectCommand(object obj)
        {
            try
            {
                ProjectDataPersister.AddNewProject(NewProject);
                NavigationUtil.CloseAddNewProjectWindow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public ICommand ExportToWordCommand
        {
            get
            {
                if(exportToWordCommand==null)
                {
                    exportToWordCommand = new RelayCommand(HandleExportToWordCommand);
                }

                return exportToWordCommand;
            }
        }

        private void HandleExportToWordCommand(object obj)
        {
            NewProject.Name = ViewsDataPersister.chooseProjectWindow.labelNewProjectName.Content.ToString();

            var times =
                         from t in WorkTimeDataPersister.GetAllTimesByProject(NewProject.Name)
                         select new Tuple<string, string, string>
                         (
                            t.Task.Project.Name,
                            t.Task.Name,
                            t.Time.ToString()
                         );

            List<string> timesList = new List<string>();

            foreach (Tuple<string, string, string> item in times)
            {
                timesList.Add(String.Format("{0} {1} {2}", item.Item1, item.Item2, item.Item3));
            }

            ExportUtil.ExportToWord(timesList);

        }

        public ICommand ExportToExcelCommand
        {
            get
            {
                if (exportToExcelCommand == null)
                {
                    exportToExcelCommand = new RelayCommand(HandleExportToExcelCommand);
                }

                return exportToExcelCommand;
            }
        }

        private void HandleExportToExcelCommand(object obj)
        {
            NewProject.Name = ViewsDataPersister.chooseProjectWindow.labelNewProjectName.Content.ToString();

            var times =
                         from t in WorkTimeDataPersister.GetAllTimesByProject(NewProject.Name)
                         select new Tuple<string, string, string>
                         (
                            t.Task.Project.Name,
                            t.Task.Name,
                            t.Time.ToString()
                         );

            List<string> timesList = new List<string>();

            foreach (Tuple<string, string, string> item in times)
            {
                timesList.Add(String.Format("{0} {1} {2}", item.Item1, item.Item2, item.Item3));
            }

            ExportUtil.ExportToExcel(timesList);
        }

        public ICommand ExportToTXTCommand
        {
            get
            {
                if (exportToTXTCommand == null)
                {
                    exportToTXTCommand = new RelayCommand(HandleExportToTXTCommand);
                }

                return exportToTXTCommand;
            }
        }

        private void HandleExportToTXTCommand(object obj)
        {
            NewProject.Name = ViewsDataPersister.chooseProjectWindow.labelNewProjectName.Content.ToString();

            var times =
                         from t in WorkTimeDataPersister.GetAllTimesByProject(NewProject.Name)
                         select new Tuple<string, string, string>
                         (
                            t.Task.Project.Name,
                            t.Task.Name,
                            t.Time.ToString()
                         );

            List<string> timesList = new List<string>();

            foreach (Tuple<string, string, string> item in times)
            {
                timesList.Add(String.Format("{0} {1} {2}", item.Item1, item.Item2, item.Item3));
            }

            ExportUtil.ExportToTXT(timesList);
        }
    }
}
