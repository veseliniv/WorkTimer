using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.ViewModels
{
    public class WorkTimesViewModel
    {
        public TimeViewModel Time { get; set; }
        public TaskViewModel Task { get; set; }
        public ProjectViewModel Project { get; set; }
    }
}
