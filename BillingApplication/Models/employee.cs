using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApplication.Models
{
    public class employee
    {
        public long ID { get; set; }
        public string Emp_Number { get; set; }
        public string Emp_Name { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public Nullable<double> Previous_Exp { get; set; }
        public Nullable<double> ImSS_Exp { get; set; }
        public Nullable<double> Total_Exp { get; set; }
        public string Domain { get; set; }
        public string Business_Unit { get; set; }
        public string Reporting { get; set; }
        public string Primary_Skills { get; set; }
        public string Secondary_Skills { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Mobile_Number { get; set; }
        public string Replaced_by { get; set; }
        public Nullable<System.DateTime> Relived_Date { get; set; }
        public Nullable<System.DateTime> Start_Date { get; set; }
        public Nullable<System.DateTime> End_Date { get; set; }
    }
}