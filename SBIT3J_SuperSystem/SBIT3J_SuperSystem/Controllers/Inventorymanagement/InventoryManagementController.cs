using SBIT3J_SuperSystem.Models;
using SBIT3J_SuperSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Controllers.Inventorymanagement
{
    public class InventoryManagementController : Controller
    {
        private SBIT3JEntities objSBIT3JEntities;

        // Use a protected or public constructor
        public InventoryManagementController()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }

        // GET: InventoryManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReturnRefund()
        {
            return View();
        }

        // GET: Restock
        public ActionResult Restock()
        {
            // Get all products for the dropdown
            ProductRepository objProductRepository = new ProductRepository();
            var products = objProductRepository.GetAllProduct();

            // Get all restocks for the view
            var restocks = objSBIT3JEntities.Restocks.ToList();

            // Create a model to hold both the products and restocks
            var objMultipleModel = new Tuple<IEnumerable<SelectListItem>, List<Restock>>(products, restocks);

            return View(objMultipleModel);
        }



        [HttpGet]
        public JsonResult getItemUnitPrice(int ProductID)
        {
            decimal price = (decimal)objSBIT3JEntities.Products.Single(model => model.ProductID == ProductID).Price;
            return Json(price, JsonRequestBehavior.AllowGet);

        }


    }
}
