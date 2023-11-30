using SBIT3J_SuperSystem.Models;
using SBIT3J_SuperSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Controllers.Inventorymanagement
{
    public class RestockController : Controller
    {
        private SBIT3JEntities objSBIT3JEntities;

        RestockController()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }

        // GET: Restock
        public ActionResult Index()
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
    }
}
