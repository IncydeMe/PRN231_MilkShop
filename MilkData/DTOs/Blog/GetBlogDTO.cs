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

        public int AccountId { get; set; }

        public string Title { get; set; } = null!;

        public string? BlogContent { get; set; }

        public string? ImageUrl { get; set; }

        public string? ProductSuggestUrl { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string? CategoryName { get; set; }

        public string? Reference { get; set; }

        public int? Priority { get; set; }
    }
}
