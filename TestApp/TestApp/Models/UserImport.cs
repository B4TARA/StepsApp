using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models
{
    [Serializable]
    class UserImport
    {
        public int Day { get; set; }
        public int Rank { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public int Steps { get; set; }
        public int AvgSteps { get; set; }
        public int MaxSteps { get; set; }
        public int MinSteps { get; set; }
    }
}
