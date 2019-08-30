using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApplication.Models
{
    public class customer
    {
        public long ID { get; set; }
        public string Emp_Name { get; set; }
        public string Client_Name { get; set; }
        public string Email { get; set; }
        public string Reporting_Manager_at_client_place { get; set; }
        public string Shadow { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Cilent_Start_Date { get; set; }
        public Nullable<System.DateTime> Cilent_End_Date { get; set; }

    }
}