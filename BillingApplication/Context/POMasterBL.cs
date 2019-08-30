using BillingApplication.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingApplication.Context
{
    public class POMasterBL
    {
        //linq query used to retrive POMaster details from (ImSS_Master_Emp_List) 
        public List<ImSS_Master_PO> GetPOList()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {

                    var polist = (from po in context.ImSS_Master_PO select po).ToList();

                    return polist;
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

        //ling query used to get currency(ImSS_Curr)
        public List<ImSS_Currency> GetCurrency()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Currency select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //ling query used to get payment(ImSS_Payment_Mode)
        public List<ImSS_Payment_Mode> GetPayment()
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    var list = (from a in context.ImSS_Payment_Mode select a).ToList();
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //linq query used to insert POMaster details into (ImSS_Master_Emp_List)
        public ImSS_Master_PO AddPOMaster(ImSS_Master_PO po)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    context.ImSS_Master_PO.Add(po);
                    context.SaveChanges();
                    return po;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
          }

        //linq query used to delete PO details of (ImSS_Master_PO)
        public List<ImSS_Master_PO> Delete(int? Id)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    ImSS_Master_PO DeleteCilent = (from c in context.ImSS_Master_PO where c.ID == Id select c).FirstOrDefault();
                    if (DeleteCilent != null)
                    {
                        context.ImSS_Master_PO.Remove(DeleteCilent);
                        context.SaveChanges();
                    }
                    return (from a in context.ImSS_Master_PO select a).ToList();
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //linq query used to update po details of (ImSS_Master_PO)
        public List<ImSS_Master_PO> UpdatePO(ImSS_Master_PO po)
        {
            try
            {
                using (var context = new Billing_StagingEntities1())
                {
                    ImSS_Master_PO UpdatePo = (from c in context.ImSS_Master_PO where c.ID == po.ID select c).FirstOrDefault();
                    UpdatePo.Client_Name = po.Client_Name;
                    UpdatePo.Project_Name = po.Project_Name;
                    UpdatePo.PO_Number = po.PO_Number;
                    UpdatePo.Point_Of_Contact = po.Point_Of_Contact;
                    UpdatePo.Mode_Of_Payment = po.Mode_Of_Payment;
                    UpdatePo.Currency = po.Currency;
                    UpdatePo.PO_StartDate = po.PO_StartDate;
                    UpdatePo.PO_EndDate = po.PO_EndDate;
                    UpdatePo.PO_Initial_Amount = po.PO_Initial_Amount;
                    UpdatePo.PO_Duration = po.PO_Duration;
                    UpdatePo.PO_Renewed_Amount = po.PO_Renewed_Amount;
                    UpdatePo.PO_Renewed_Date = po.PO_Renewed_Date;
                    UpdatePo.Parent_PO = po.Parent_PO;
                    UpdatePo.PO_Status = po.PO_Status;
                    UpdatePo.PO_Total_Amount_INR = po.PO_Total_Amount_INR;
                    UpdatePo.PO_Close_Date = po.PO_Close_Date;
                    context.SaveChanges();
                    return (from a in context.ImSS_Master_PO select a).ToList();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}