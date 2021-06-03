using System;
using System.Collections.Generic;
using System.Text;

namespace FirebasePayRoll.Model
{
    public class Payrolldb
    {
        public int EmpNum { get; set; }
        public string Name { get; set; }
        public double HoursWork { get; set; }
        public string EmpStat { get; set; }
        public string CivilStat { get; set; }
        public double Gross { get; set; }
        public double Deduction { get; set; }
        public double Net { get; set; }
    }
}
