using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EpicVitamins.Models;
using System.Collections.Generic;

namespace EpicVitamins.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        [TestMethod]
        public void CommitOrderTest()
        {
            //Arrange
            var order = new Order
            {
                FirstName = "David", LastName = "Thompson",
                Address = "123 SomeStreet", City = "Dallas",
                State = "TX", Zip = "75207",

                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { ItemCode="abcd", Description="Cool Item", PriceEach=1.2M, Quantity=1M, Total=1.2M}
                }

            };

            var svc = new OrderService();

            //Act
            var orderID = svc.CommitOrder(order);

            //Assert
            var checkOrder = svc.GetOrder(orderID);

            Assert.AreEqual(order.FirstName, checkOrder.FirstName, "FirstName");

            Assert.AreEqual("abcd", checkOrder.OrderDetails.First().ItemCode, "First Item Code");

        }
    }
}
