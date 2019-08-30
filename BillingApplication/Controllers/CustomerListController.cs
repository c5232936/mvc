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
    public class CustomerListController : Controller
    {
        CustomerBl CBL = new CustomerBl();
        //service method called from bussinesslayer(CustomerBL) to retrive data from Customer details(ImSS_Master_Client)
        public ActionResult CustomerList()
        {
            try
            {
                List<customer> listcust = new List<customer>();
                listcust = CBL.GetCustomerList();
                ViewBag.Customerlist = listcust;
                ViewBag.EmployeeNameList = new SelectList(CBL.GetEmployeeNameList(), "Emp_Name", "Emp_Name");
                ViewBag.ClientList = new SelectList(CBL.GetClientList(), "Client_Name", "Client_Name");
                ViewBag.ShadowList = new SelectList(CBL.GetShadowList(), "Shadow", "Shadow");
                ViewBag.StatusList = new SelectList(CBL.GetStatusList(), "Cilent_Status", "Cilent_Status");
                ViewBag.LocationList = new SelectList(CBL.GetLocationList(), "Location", "Location");

                return View();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //inserting customer details
        [HttpPost]
        public ActionResult CreateCustomer(ImSS_Master_Client emp)
        {
            try
            {
                ImSS_Master_Client Addcust = new ImSS_Master_Client();
                Addcust = CBL.AddCustomer(emp);
                return Json(emp);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //editing employee details
        [HttpPost]
        public ActionResult EditList(ImSS_Master_Client cl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CBL.UpdateCilent(cl);
                }
                return Json(cl);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        
        //dropdown for employeename
        [HttpGet]
        public ActionResult GetEmployeeNameList()
        {
            try
            {
                List<ImSS_Master_Emp_List> list = new List<ImSS_Master_Emp_List>();
                list = CBL.GetEmployeeNameList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for client
        [HttpGet]
        public ActionResult GetClientList()
        {
            try
            {
                List<ImSS_Client_List> list1 = new List<ImSS_Client_List>();
                list1 = CBL.GetClientList();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for shadow
        [HttpGet]
        public ActionResult GetShadowList()
        {
            try
            {
                List<ImSS_Shadow> list = new List<ImSS_Shadow>();
                list = CBL.GetShadowList();
                return Json(list, JsonRequestBehavior.AllowGet);
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
                List<ImSS_Cilent_Status> list1 = new List<ImSS_Cilent_Status>();
                list1 = CBL.GetStatusList();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       

        //dropdown for location
        [HttpGet]
        public ActionResult GetLocationList()
        {
            try
            {
                List<ImSS_Location> list1 = new List<ImSS_Location>();
                list1 = CBL.GetLocationList();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}