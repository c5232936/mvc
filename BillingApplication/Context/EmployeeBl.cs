
using BillingApplication.DBContexts;
using BillingApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace BillingApplication.Context
{
    public class EmployeeBl
    {

        //linq query used to retrive employee details from (ImSS_Master_Emp_List) 
        public List<employee> GetEmployeeList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var employeeList = (from a in context.ImSS_Master_Emp_List
                                        join b in context.ImSS_Emp_Details on a.Emp_Number equals b.Employee_ID
                                        where b.End_Date == null
                                        select new employee
                                        {
                                            ID = a.ID,
                                            Emp_Number = a.Emp_Number,
                                            Emp_Name = a.Emp_Name,
                                            DOJ = a.DOJ,
                                            Previous_Exp = a.Previous_Exp,
                                            ImSS_Exp = a.ImSS_Exp,
                                            Total_Exp = a.Total_Exp,
                                            Domain = a.Domain,
                                            Business_Unit = a.Business_Unit,
                                            Reporting = a.Reporting,
                                            Start_Date = b.Start_Date,
                                            Primary_Skills = a.Primary_Skills,
                                            Secondary_Skills = a.Secondary_Skills,
                                            Category = a.Category,
                                            Status = a.Status,
                                            Mobile_Number = a.Mobile_Number,
                                            Replaced_by = a.Replaced_by,
                                            Relived_Date = a.Relived_Date
                                        }).ToList();
                    return employeeList;

                }

            }

            catch (Exception e)
            {
                throw e;
            }


        }


        //linq query used to insert employee details into (ImSS_Master_Emp_List)
        //public ImSS_Master_Emp_List AddEmployee(ImSS_Master_Emp_List Addemp)
        //{
        //    try
        //    {
        //        using (var context = new Billing_StagingEntities1())
        //        {
        //            ImSS_Emp_Details lst=new ImSS_Emp_Details();
        //            lst.Start_Date = DateTime.Now;
        //            lst.Employee_ID = Addemp.Emp_Number;
        //            lst.Manager_ID = Addemp.Reporting;
        //            context.ImSS_Master_Emp_List.Add(Addemp);
        //            context.ImSS_Emp_Details.Add(lst);
        //            context.SaveChanges();
        //            return Addemp;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //}

        public ImSS_Master_Emp_List AddEmployee(ImSS_Master_Emp_List Addemp)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    ImSS_Emp_Details lst = new ImSS_Emp_Details();
                    lst.Start_Date = DateTime.Now;
                    lst.Employee_ID = Addemp.Emp_Number;
                    lst.Manager_ID = Addemp.Reporting;
                    context.ImSS_Master_Emp_List.Add(Addemp);
                    context.ImSS_Emp_Details.Add(lst);
                    context.SaveChanges();
                    return Addemp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        //linq query used to update employee details of (ImSS_Master_Emp_List)
        public List<ImSS_Master_Emp_List> UpdateEmployee(ImSS_Master_Emp_List empl)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    ImSS_Master_Emp_List UpdateEmployee = (from c in context.ImSS_Master_Emp_List where c.ID == empl.ID select c).FirstOrDefault();
                    UpdateEmployee.Emp_Number = empl.Emp_Number;
                    UpdateEmployee.Emp_Name = empl.Emp_Name;
                    UpdateEmployee.DOJ = empl.DOJ;
                    UpdateEmployee.Previous_Exp = empl.Previous_Exp;
                    UpdateEmployee.ImSS_Exp = empl.ImSS_Exp;
                    UpdateEmployee.Total_Exp = empl.Total_Exp;
                    UpdateEmployee.Domain = empl.Domain;
                    UpdateEmployee.Business_Unit = empl.Business_Unit;
                    UpdateEmployee.Reporting = empl.Reporting;
                    UpdateEmployee.Primary_Skills = empl.Primary_Skills;
                    UpdateEmployee.Secondary_Skills = empl.Secondary_Skills;
                    UpdateEmployee.Category = empl.Category;
                    UpdateEmployee.Status = empl.Status;
                    UpdateEmployee.Mobile_Number = empl.Mobile_Number;
                    UpdateEmployee.Replaced_by = empl.Replaced_by;
                    UpdateEmployee.Relived_Date = empl.Relived_Date;

                    context.SaveChanges();
                    var val = (from e in context.ImSS_Emp_Details
                               where e.Employee_ID == empl.Emp_Number && e.Manager_ID == empl.Reporting
                               && e.End_Date == null
                               select e).Count();
                    if (val == 0)
                    {
                        ImSS_Emp_Details Empdet = (from c in context.ImSS_Emp_Details where c.Employee_ID == empl.Emp_Number && c.End_Date == null select c).FirstOrDefault();
                        Empdet.End_Date = DateTime.Now;
                       

                        
                        ImSS_Emp_Details lst = new ImSS_Emp_Details();
                        lst.Start_Date = DateTime.Now;
                        lst.Employee_ID = empl.Emp_Number;
                        lst.Manager_ID = empl.Reporting;
                        
                        context.ImSS_Emp_Details.Add(lst);
                        context.SaveChanges();

                    }

                    return (from a in context.ImSS_Master_Emp_List select a).ToList();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //linq query used to delete employee details of (ImSS_Master_Emp_List)
        //public List<ImSS_Master_Emp_List> Delete(string empno)
        //{
        //    try
        //    {
        //        using (var context = new Billing_StagingEntities1())
        //        {
        //            ImSS_Master_Emp_List DeleteEmployee = (from c in context.ImSS_Master_Emp_List where c.Emp_Number == empno  select c).FirstOrDefault();
        //            if (DeleteEmployee != null)
        //            {
        //                context.ImSS_Master_Emp_List.Remove(DeleteEmployee);
        //                context.SaveChanges();
        //            }
        //            return (from a in context.ImSS_Master_Emp_List select a).ToList();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //ling query used to get who to report(ImSS_Reporting_Head)
        public List<ImSS_Reporting_Head> GetReportingList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Reporting_Head select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get bussinessunit(ImSS_Business_Unit)
        public List<ImSS_Business_Unit> GetBussinessUnitList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Business_Unit select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get Domain(ImSS_Domain)
        public List<ImSS_Domain> GetDomainList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Domain select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get status(ImSS_Status)
        public List<ImSS_Status> GetStatusList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Status where a.ID != 5 select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get category(ImSS_Category)
        public List<ImSS_Category> GetcategoryList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Category select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
