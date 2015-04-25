using EpicVitamins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpicVitamins.Controllers
{
    public class AdminController : Controller
    {
        private EpicVitaminsDb _context = new EpicVitaminsDb();


        public ActionResult OrderList()
        {
            //var results = MockOrders();

            var results = _context.Orders.ToList();


            return View(results);
        }

        public ActionResult Details(int id)
        {
            var results = MockOrders();

            var order = results.FirstOrDefault(a => a.OrderID == id);

            if (order == null)
            {
                return RedirectToAction("OrderList");
            }

            return View(order);
        }

        private IEnumerable<Order> MockOrders()
        {
            var results = new List<Order>
            {
                new Order
                {
                    OrderID     = 1,
                    Address     = "123 Some Street",
                    City        = "CIty",
                    FirstName   = "DUstin",
                    LastName    = "Test",
                    OrderDetails = new List<OrderDetail> { new OrderDetail { Description = "Hiya", OrderID  =1 }}
                },
                new Order
                {
                    OrderID     = 2,
                    Address     = "ORDER 2 123 Some Street",
                    City        = "ORDER 2 CIty",
                    FirstName   = "ORDER 2 DUstin",
                    LastName    = "ORDER 2 Test",
                    OrderDetails = new List<OrderDetail> { new OrderDetail { Description = "Hiya", OrderID  =1 }}
                },
                new Order
                {
                    OrderID     = 3,
                    Address     = "ORDER 3 123 Some Street",
                    City        = "ORDER 3 CIty",
                    FirstName   = "ORDER 3 DUstin",
                    LastName    = "ORDER 3 Test",
                    OrderDetails = new List<OrderDetail> { new OrderDetail { Description = "Hiya", OrderID  =1 }}
                },
            };

            return results;
        }

    }
}