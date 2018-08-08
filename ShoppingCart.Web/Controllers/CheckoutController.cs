using ShoppingCart.Core.Interfaces;
using ShoppingCart.Core.Interfaces.Service;
using ShoppingCart.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Web.Controllers
{
    public class CheckoutController : Controller
    {
        IOrderService orderService;
        IShopingCartService shopingCartService;

        List<string> CreditCardTypes = new List<string>();
        public CheckoutController(IOrderService orderService, IShopingCartService shopingCartService)
        {
            this.orderService = orderService;
            this.shopingCartService = shopingCartService;
            CreditCardTypes.Add("Amex");
            CreditCardTypes.Add("Visa");
            CreditCardTypes.Add("MasterCard");
        }
        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            ViewBag.CreditCardTypes = CreditCardTypes;
            //User.Identity.Name
            var previousOrder = orderService.GetPreviousOrder("Priyantha");

            if (previousOrder != null)
                return View(previousOrder);
            else
                return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            ViewBag.CreditCardTypes = CreditCardTypes;
            string result = values[9];

            var order = new Order();
            TryUpdateModel(order);
            order.CreditCard = result;

            try
            {
                order.Username = "Priyantha";// User.Identity.Name;
                order.Email = "Priyantha@gmail.com";// User.Identity.Name;
                order.OrderDate = DateTime.Now;
                //var currentUserId = "";//User.Identity.GetUserId();
                var cartId = this.shopingCartService.GetCartId(this.HttpContext);
                order = this.orderService.CreateOrder(order, cartId);
                                
                return RedirectToAction("Complete",  new { id = order.OrderId });

            }
            catch(Exception e)
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = this.orderService.IsValidOder(id, "Priyantha");

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}