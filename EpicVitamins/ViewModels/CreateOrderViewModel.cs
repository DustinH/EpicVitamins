using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicVitamins.ViewModels
{
    public class CreateOrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public decimal Quantity { get; set; }
    }
}