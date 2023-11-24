using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Controllers.Inventorymanagement
{
    public class InventoryManagementController : Controller
    {
        // GET: InventoryManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReturnRefund()
        {
            return View();
        }
    }
}