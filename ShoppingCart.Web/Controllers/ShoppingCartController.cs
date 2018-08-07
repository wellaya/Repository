using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        IShopingCartService service;
        public ShoppingCartController(IShopingCartService service)
        {
            this.service = service;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            
            string id = this.service.GetCartId(this.HttpContext);
            var viewModel = this.service.GetCart(id);
            return View(viewModel);
        }

       
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            string Cartid = this.service.GetCartId(this.HttpContext);
            var results = this.service.AddToCart(id, Cartid);
            //return RedirectToAction("Index");
            return Json(results);
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            string Cartid = this.service.GetCartId(this.HttpContext);
            var results = this.service.RemoveItem(Cartid,id);
            //return RedirectToAction("Index");
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            string id = this.service.GetCartId(this.HttpContext);
            ViewData["CartCount"] = this.service.GetCount(id);
            return PartialView("CartSummary");
        }
    }
}