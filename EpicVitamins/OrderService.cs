using EpicVitamins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicVitamins
{
    public class OrderService
    {
        EpicVitaminsDb _db = new EpicVitaminsDb();

        public int CommitOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order.OrderID;
        }

        public Order GetOrder(int orderID)
        {
            return _db.Orders.Find(orderID);
        }
    }
}