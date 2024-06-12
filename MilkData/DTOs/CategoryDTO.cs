using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class CategoryDTO
    {
        public int ProductCategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string HttpMethod { get; set; }
    }
}
