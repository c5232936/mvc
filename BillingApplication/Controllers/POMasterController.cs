using BillingApplication.Context;
using BillingApplication.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BillingApplication.Controllers
{
    public class POMasterController : Controller
    {
        POMasterBL PBL = new POMasterBL(); //creating a object of bussiness layer
        
        //fetch data from POMaster Table
        [HttpGet]
        public ActionResult POMaster()
        {
            try
            {
                List<ImSS_Master_PO> listObj = new List<ImSS_Master_PO>();
                listObj = PBL.GetPOList();
                ViewBag.clientList = new SelectList(PBL.GetClientList(), "Client_Name", "Client_Name");
                ViewBag.paymentList = new SelectList(PBL.GetPayment(), "Payment", "Payment");
                ViewBag.currencyList = new SelectList(PBL.GetCurrency(), "Currency", "Currency");

                return View(listObj);
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
                list1 = PBL.GetClientList();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for Currency
        [HttpGet]
        public ActionResult GetCurrencyRate()
        {
            try
            {
                List<ImSS_Currency> list1 = new List<ImSS_Currency>();
                list1 = PBL.GetCurrency();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //dropdown for Currency
        [HttpGet]
        public ActionResult GetPaymentMode()
        {
            try
            {
                List<ImSS_Payment_Mode> list1 = new List<ImSS_Payment_Mode>();
                list1 = PBL.GetPayment();
                return Json(list1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //inserting POMaster details
        [HttpPost]
        public ActionResult InsertPO(ImSS_Master_PO po)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PBL.AddPOMaster(po);

                }
                return Json(po);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //editing employee details
        [HttpPost]
        public ActionResult Edit(ImSS_Master_PO po)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PBL.UpdatePO(po);

                }
                return Json(po);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //delete PO details
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            try
            {

                List<ImSS_Master_PO> PO = new List<ImSS_Master_PO>();
                if (id != null)
                {
                    PO = PBL.Delete(id);
                }
                return Json(PO);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}