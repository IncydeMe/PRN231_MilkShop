using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs.Voucher
{
    public class VoucherDTO
    {
        public Guid VoucherId { get; set; }

        public int Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Type { get; set; }

        public string? Description { get; set; }

        public string? Status { get; set; }
    }
}
