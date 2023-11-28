using SBIT3J_SuperSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Repositories
{
    public class RestockRepository
    {
        private SBIT3JEntities objSBIT3JEntities;

        public RestockRepository()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }
        public IEnumerable<SelectListItem> GetAllUser()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objSBIT3JEntities.Users
                                  select new SelectListItem()
                                  {
                                      Text = obj.Username,
                                      Value = obj.UserID.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}