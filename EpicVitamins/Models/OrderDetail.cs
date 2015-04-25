using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicVitamins.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal PriceEach { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
    }
}