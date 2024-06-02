using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DTOs
{
    public record AccountDTO
    (
        int AccountId,
        string FullName,
        string Email,
        string Password,
        string Phone,
        string Address,
        string Role,
        int Point,
        bool IsActive
    );

    public record CreateAccountDTO
    (
        string FullName,
        string Email,
        string Password,
        string Phone,
        string Address
    );
}
