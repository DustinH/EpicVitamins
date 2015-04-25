using EpicVitamins.Models;
using EpicVitamins.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpicVitamins.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(CreateOrderViewModel model)
        {
            var svc = new OrderService();
            var orderID = svc.CommitOrder(
                new Order
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,

                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail {ItemCode = "abgcd", Quantity=model.Quantity, Description = "cool",PriceEach=1,Total = 1*model.Quantity}
                    }
                }
                
                );
            return RedirectToAction("ThankYou", new { id = orderID });
        }

        public ActionResult ThankYou(int id)
        {
            var svc = new OrderService();
            var model = svc.GetOrder(id);
            return View(model);
        }
    }
}