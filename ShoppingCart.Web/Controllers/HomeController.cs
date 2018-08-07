using ShoppingCart.Core;
using ShoppingCart.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ShoppingCart.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository service;
        public HomeController(IProductRepository service)
        {

            this.service = service;
        }
        public ActionResult Index()
        {
            //var prods = this.service.GetProducts().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase xmlFile)
        {
            if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
            {
                var xmlPath = Server.MapPath("~/FileUpload" + xmlFile.FileName);
                xmlFile.SaveAs(xmlPath);
                XDocument xDoc = XDocument.Load(xmlPath);
                List<Product> productList = xDoc.Descendants("product").Select
                    (product => new Product
                    {
                        Id = Convert.ToInt32(product.Element("id").Value),
                        Name = product.Element("name").Value,
                        Price = Convert.ToDecimal(product.Element("price").Value),
                       // Quantity = Convert.ToInt32(product.Element("quantity").Value)
                    }).ToList();

                
                    //foreach (var i in productList)
                    //{
                    //    var v = db.GetProducts().Where(a => a.Id.Equals(i.Id)).FirstOrDefault();

                    //    if (v != null)
                    //    {
                    //        v.Id = i.Id;
                    //        v.Name = i.Name;
                    //        v.Price = i.Price;
                    //       // v.Quantity = i.Quantity;
                    //    }
                    //    else
                    //    {
                    //        db.Add(i);
                    //    }
                        
                    //}
                
                ViewBag.Success = "File uploaded successfully..";
            }
            else
            {
                ViewBag.Error = "Invalid file(Upload xml file only)";
            }
            return View("Index");
        }
    }
}