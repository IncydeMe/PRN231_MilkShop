using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public class CategoryDTO
    {
        public class CreateCategoryDTO
        {
            public string CategoryName { get; set; } = null!;
        }

        public class UpdateCategoryDTO
        {
            public string CategoryName { get; set; } = null!;
        }
    }
}
