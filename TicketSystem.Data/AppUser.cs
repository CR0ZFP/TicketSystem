using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Data
{
    public class AppUser
    {
        [StringLength(200)]
        public required string FirstName { get; set; } = string.Empty;
        [StringLength(200)]
        public required string LastName { get; set; } = string.Empty;
        [StringLength(200)]
        public required string RefreshToken { get; set; } = string.Empty;
    }
}
