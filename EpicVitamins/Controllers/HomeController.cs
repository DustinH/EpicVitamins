using EpicVitamins.Models;
using EpicVitamins.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
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

            var order =                 new Order
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
                };

            var orderID = svc.CommitOrder(order);

            SendEmailNotification(order);

            return RedirectToAction("ThankYou", new { id = orderID });
        }

        private void SendEmailNotification(Order order)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Thank you for your order.  Your order number is {0}", order.OrderID);
            sb.AppendLine("Please come again");

            using (var client = new SmtpClient())
            {
                var message = new MailMessage();
                message.To.Add("dustin@epicservers.com");
                // etc

                client.Send(message);
            }
        }

        public ActionResult ThankYou(int id)
        {
            var svc = new OrderService();
            var model = svc.GetOrder(id);
            return View(model);
        }
    }
}