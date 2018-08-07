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

        // GET: /Store/AddToCart/5
        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            return View();
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            return View();
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