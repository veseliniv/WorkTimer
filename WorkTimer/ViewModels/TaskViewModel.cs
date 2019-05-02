using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimer.ViewModels
{
    public class TaskViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ProjectViewModel Project { get; set; }
    }
}
