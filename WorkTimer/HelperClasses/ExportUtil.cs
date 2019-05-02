using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkTimer.DataPersisters;

namespace WorkTimer.HelperClasses
{
    public class ExportUtil
    {
        private static SaveFileDialog saveFileDialog = new SaveFileDialog();

        internal static void ExportToWord(IEnumerable<string> textToFile)
        {
            saveFileDialog.Filter = @"Microsoft Word Document| *.doc | All(*.*) | *";
            
            if(saveFileDialog.ShowDialog()==true)
            {
                File.WriteAllLines(saveFileDialog.FileName, textToFile);
            }
        }

        internal static void ExportToExcel(IEnumerable<string> textToFile)
        {
            saveFileDialog.Filter = @"Microsoft Excel Document| *.xls | All(*.*) | *";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, textToFile);
            }
        }

        internal static void ExportToTXT(IEnumerable<string> textToFile)
        {
            saveFileDialog.Filter = @"Normal text file| *.txt | All(*.*) | *";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, textToFile);
            }
        }

        internal static void Export(string projectName, string buttonPressedName)
        {
            var times =
                         from t in WorkTimeDataPersister.GetAllTimesByProject(projectName)
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

            switch (buttonPressedName)
            {
                case "buttonExportToWord":
                     ExportToWord(timesList);
                     break;

                case "buttonExportToExcel":
                     ExportToExcel(timesList);
                     break;

                case "buttonExportToTXT":
                     ExportToTXT(timesList);
                     break;
            }
        }
    }
}
