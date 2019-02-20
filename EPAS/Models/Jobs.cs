using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAS.Models
{
    /// <summary>
    /// Generic class
    /// </summary>
    public class Jobs
    {
        public int week { get; set; }
        public string day { get; set; }
        public string target { get; set; }
        public string responsibility { get; set; }
        public string task { get; set; }
        public string approval { get; set; }

        public override bool Equals(object obj)
        {
            return ((Jobs)obj).day == day && ((Jobs)obj).responsibility == responsibility;
        }

        public override int GetHashCode()
        {
            return (day.ToString() + responsibility).GetHashCode();
        }
    }
}
