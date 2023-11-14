using SBIT3J_SuperSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Repositories
{
    public class ProductRepository
    {
        private SBIT3JEntities objSBIT3JEntities;

        public ProductRepository()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }
        public IEnumerable<SelectListItem> GetAllProduct()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objSBIT3JEntities.Products
                                  select new SelectListItem()
                                  {
                                      Text = obj.ProductName,
                                      Value = obj.ProductID.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
    
}