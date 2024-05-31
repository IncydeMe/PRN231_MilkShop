﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class ProductDTO
    {
        public class CreateProductDTO
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string ImageUrl { get; set; } = null!;
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
        }

        public class UpdateProductDTO
        {
            public string Name { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string ImageUrl { get; set; } = null!;
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
        }
    }
}
