using SBIT3J_SuperSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Repositories
{
    public class DiscountRepository
    {

        private SBIT3JEntities objSBIT3JEntities;

        public DiscountRepository()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }
        public IEnumerable<SelectListItem> GetAllDiscount()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objSBIT3JEntities.Discounts
                                  select new SelectListItem()
                                  {
                                      Text = obj.DiscountName,
                                      Value = obj.DiscountID.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}