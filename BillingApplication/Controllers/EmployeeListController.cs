using BillingApplication.Context;
using BillingApplication.DBContexts;
using BillingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingApplication.Controllers
{
    public class EmployeeListController : Controller
    {

        EmployeeBl EBL = new EmployeeBl(); //creating a object of bussiness layer


        //service method called from bussinesslayer(EmployeeBL) to retrive data from employee details(ImSS_Master_Emp_List)
        [HttpGet]
        public ActionResult EmployeeList()
        {
            try {
                List<employee> listObj = new List<employee>();
                listObj = EBL.GetEmployeeList();
                ViewBag.employeelist = listObj;
                ViewBag.ReportingList = new SelectList(EBL.GetReportingList(), "Reporting_Head", "Reporting_Head");
                ViewBag.BussinessUnitList = new SelectList(EBL.GetBussinessUnitList(), "Business_Unit", "Business_Unit");
                ViewBag.DomainList = new SelectList(EBL.GetDomainList(), "Domain_Name", "Domain_Name");
                ViewBag.StatusList = new SelectList(EBL.GetStatusList(), "ImSS_Skills_Category", "ImSS_Skills_Category");
                ViewBag.categoryList = new SelectList(EBL.GetcategoryList(), "Category", "Category");
                return View();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

        
        //inserting employee details
        [HttpPost]
        public ActionResult CreateEmployee(ImSS_Master_Emp_List emp)
        {
            try
            { 
                if(ModelState.IsValid)
                {
                    EBL.AddEmployee(emp);
                }
                return Json(emp);
            }
            catch(Exception e)
            {
                throw e;
            }
        }


        //editing employee details
        [HttpPost]
        public ActionResult Edit(ImSS_Master_Emp_List emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EBL.UpdateEmployee(emp);

                }
                return Json(emp);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //delete employee details
        //[HttpPost]
        //public ActionResult Delete(string Emp_Number)
        //{
        //    try
        //    {

        //        List<ImSS_Master_Emp_List> em = new List<ImSS_Master_Emp_List>();
        //        if (Emp_Number != null)
        //        {
        //            em = EBL.Delete(Emp_Number);
        //        }
        //        return Json(em);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //dropdown for reporting
        [HttpGet]
        public ActionResult GetReportingList()
        {
            try {
                List<ImSS_Reporting_Head> list = new List<ImSS_Reporting_Head>();
                list = EBL.GetReportingList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        //dropdown for bussinessunit
        [HttpGet]
        public ActionResult GetBussinessUnitList()
        {
            try
            {
                List<ImSS_Business_Unit> list1 = new List<ImSS_Business_Unit>();
                list1 = EBL.GetBussinessUnitList();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for domain
        [HttpGet]
        public ActionResult GetDomainList()
        {
            try
            {
                List<ImSS_Domain> list2 = new List<ImSS_Domain>();
                list2 = EBL.GetDomainList();
                return Json(list2, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for status
        [HttpGet]
        public ActionResult GetStatusList()
        {
            try
            {
                List<ImSS_Status> list3 = new List<ImSS_Status>();
                list3 = EBL.GetStatusList();
                return Json(list3, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for category
        [HttpGet]
        public ActionResult GetcategoryList()
        {
            try
            {
                List<ImSS_Category> list4 = new List<ImSS_Category>();
                list4 = EBL.GetcategoryList();
                return Json(list4, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        }
    }

