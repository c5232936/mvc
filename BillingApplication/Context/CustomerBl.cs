using BillingApplication.DBContexts;
using BillingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApplication.Context
{
    public class CustomerBl
    {
        //linq query used to retrive employee details from (ImSS_Master_Emp_List) 
        public List<customer> GetCustomerList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var CustomerList = (from a in context.ImSS_Master_Client
                                        join b in context.ImSS_Cust_Emp_Details on a.Emp_Name equals b.Emp_Number
                                        select new customer
                                        {
                                              ID=a.ID,
                                              Emp_Name=a.Emp_Name,
                                              Client_Name=a.Client_Name, 
                                              Email=a.Email, 
                                              Reporting_Manager_at_client_place=a.Reporting_Manager_at_client_place,
                                              Cilent_Start_Date=b.Cilent_Start_Date,
                                              Shadow=a.Shadow, 
                                              Location=a.Location, 
                                              Status=a.Status 
                                        }).ToList();
                                        return CustomerList;

                }

            }

            catch (Exception e)
            {
                throw e;
            }


        }


        //linq query used to insert employee details into (ImSS_Master_Emp_List)
        public ImSS_Master_Client AddCustomer(ImSS_Master_Client Addcust)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    ImSS_Cust_Emp_Details lst = new ImSS_Cust_Emp_Details();
                    lst.Cilent_Start_Date = DateTime.Now;
                    lst.Emp_Number = Addcust.Emp_Name;
                    lst.Cilent_ID = Addcust.Client_Name;
                    if(Addcust.Status=="Active")
                    {
                        ImSS_Master_Emp_List UpdateEmployee = (from c in context.ImSS_Master_Emp_List where c.Emp_Name == Addcust.Emp_Name select c).FirstOrDefault();
                        UpdateEmployee.Status = "Assigned";
                    }
                    
                    context.ImSS_Master_Client.Add(Addcust);
                    context.ImSS_Cust_Emp_Details.Add(lst);
                    context.SaveChanges();
                    return Addcust;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        //linq query used to update employee details of (ImSS_Master_Emp_List)
        public List<ImSS_Master_Client> UpdateCilent(ImSS_Master_Client cust)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    ImSS_Master_Client UpdateCustomer = (from c in context.ImSS_Master_Client where c.ID == cust.ID select c).FirstOrDefault();
                    UpdateCustomer.Emp_Name = cust.Emp_Name;
                    UpdateCustomer.Client_Name = cust.Client_Name;
                    UpdateCustomer.Email = cust.Email;
                    UpdateCustomer.Reporting_Manager_at_client_place = cust.Reporting_Manager_at_client_place;
                    UpdateCustomer.Shadow = cust.Shadow;
                    UpdateCustomer.Location = cust.Location;
                    UpdateCustomer.Status = cust.Status;

                    if (UpdateCustomer.Status == "Active")
                    {
                        ImSS_Master_Emp_List UpdateEmployee = (from c in context.ImSS_Master_Emp_List where c.Emp_Name == cust.Emp_Name select c).FirstOrDefault();
                        UpdateEmployee.Status = "Assigned";
                    }
                    else
                    {
                        ImSS_Master_Emp_List UpdateEmployee = (from c in context.ImSS_Master_Emp_List where c.Emp_Name == cust.Emp_Name select c).FirstOrDefault();
                        UpdateEmployee.Status = "Avalible";
                    }
                    context.SaveChanges();


                    return (from a in context.ImSS_Master_Client select a).ToList();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get cilent(ImSS_Client_List)
        public List<ImSS_Client_List> GetClientList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Client_List select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get employee name(ImSS_Master_Emp_List)
        public List<ImSS_Master_Emp_List> GetEmployeeNameList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Master_Emp_List select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to shadow(ImSS_Shadow)
        public List<ImSS_Shadow> GetShadowList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Shadow select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //ling query used to get status(ImSS_Cilent_Status)
        public List<ImSS_Cilent_Status> GetStatusList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Cilent_Status select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        //ling query used to get location(ImSS_Location)
        public List<ImSS_Location> GetLocationList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Location select a).ToList();
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