using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Blog
{
    public class GetBlogDTO
    {
        public int BlogId { get; set; }

        public string BlogCategoryName { get; set; }

        public Guid AccountId { get; set; }

        public string Title { get; set; }

        public string DocUrl { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
