using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Threading;
using WorkTimer.ViewModels;

namespace WorkTimer.DataPersisters
{
    public class StopwatchDataPersister
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static DateTime time = new DateTime();

        internal static void StartStopwatch()
        {
            stopwatch.Start();
            ButtonPlayHidden();
        }

        internal static void PauseStopwatch()
        {
            stopwatch.Stop();
            time = DateAndElapsedTime();
            ViewsDataPersister.chooseProjectWindow.labelTimeElapsed.Content = time.ToString("dd/MM/yyyy HH:mm:ss");
            ButtonPauseHidden();
        }

        internal static void StopAndResetStopwatch()
        {
            stopwatch.Reset();
            ViewsDataPersister.chooseProjectWindow.labelTimeElapsed.Content = "00:00:00";
            ButtonPauseHidden();
        }

        internal static void RestartStopwatch()
        {
            stopwatch.Restart();
            ViewsDataPersister.chooseProjectWindow.labelTimeElapsed.Content = "00:00:00";
            ButtonPauseHidden();
        }

        internal static DateTime DateAndElapsedTime()
        {
            DateTime dateTime = new DateTime();
            DateTime today = DateTime.Today;

            dateTime = today + stopwatch.Elapsed;

            return dateTime;
        }

        private static void ButtonPlayHidden()
        {
            ViewsDataPersister.chooseProjectWindow.buttonStartTimer.Visibility = Visibility.Hidden;
            ViewsDataPersister.chooseProjectWindow.buttonPauseTimer.Visibility = Visibility.Visible;
        }

        private static void ButtonPauseHidden()
        {
            ViewsDataPersister.chooseProjectWindow.buttonStartTimer.Visibility = Visibility.Visible;
            ViewsDataPersister.chooseProjectWindow.buttonPauseTimer.Visibility = Visibility.Hidden;
        }
    }
}
