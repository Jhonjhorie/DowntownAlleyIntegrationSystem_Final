using SBIT3J_SuperSystem.Models;
using SBIT3J_SuperSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBIT3J_SuperSystem.Controllers.Inventorymanagement
{
    public class POSController : Controller
    {
        private SBIT3JEntities objSBIT3JEntities;

        public POSController()
        {
            objSBIT3JEntities = new SBIT3JEntities();
        }
        // GET: POS
        public ActionResult Index()
        {
            ProductRepository objProductRepository = new ProductRepository();
            DiscountRepository objDiscountRepository = new DiscountRepository();
            UserRepository objUserRepository = new UserRepository();

            var objMultepleModel = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objProductRepository.GetAllProduct(), objDiscountRepository.GetAllDiscount(), objUserRepository.GetAllUser());



            objSBIT3JEntities = new SBIT3JEntities();
            return View(objMultepleModel);
        }





        [HttpGet]
        public JsonResult getItemUnitPrice(int ProductID)
        {
            decimal price = (decimal)objSBIT3JEntities.Products.Single(model => model.ProductID == ProductID).Price;
            return Json(price, JsonRequestBehavior.AllowGet);

        }

    }
}