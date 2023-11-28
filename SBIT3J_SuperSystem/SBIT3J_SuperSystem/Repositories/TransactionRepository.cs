using SBIT3J_SuperSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Repositories
{
    public class TransactionRepository
    {

        private SBIT3JEntities objSBIT3JEntities;

        public TransactionRepository()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }
        public bool AddOrder(SalesTransaction objSalesTransaction)
        {
            SalesTransaction objSaleTransaction = objSalesTransaction;

            objSaleTransaction.CashierUserID = objSalesTransaction.CashierUserID;
            objSaleTransaction.DateTime = DateTime.Now;
            objSaleTransaction.TotalAmount= objSalesTransaction.TotalAmount;
            objSaleTransaction.ReceiptInfo = objSalesTransaction.ReceiptInfo;
            objSaleTransaction.CashierUserID = 100;
            objSBIT3JEntities.SalesTransactions.Add(objSaleTransaction);
            objSBIT3JEntities.SaveChanges();
            int TransactionID = objSaleTransaction.TransactionID;

            foreach (var item in objSaleTransaction.ListofOrderDetailViewModel)
            {
                SalesTransactionDetail objSalesTransactionDetail = new SalesTransactionDetail();
                objSalesTransactionDetail.TransactionID = TransactionID;
                objSalesTransactionDetail.ProductID = item.ProductID;
                objSalesTransactionDetail.DiscountID = item.DiscountID;
                objSalesTransactionDetail.Subtotal = item.Subtotal;
                objSalesTransactionDetail.PricePerUnit = item.PricePerUnit;
                objSalesTransactionDetail.QuantitySold = (-1)*item.QuantitySold;
                objSBIT3JEntities.SalesTransactionDetails.Add(objSalesTransactionDetail);
                objSBIT3JEntities.SaveChanges();
            }

            return true;
        }
    }

}