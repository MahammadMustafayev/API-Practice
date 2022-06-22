using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.ProductDTo
{
    public class CreateDTo
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double CostPrice { get; set; }
    }
}
