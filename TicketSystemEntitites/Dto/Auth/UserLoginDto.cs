using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Entitites.Dto.Auth
{
    public class UserLoginDto
    {
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
    }
}
