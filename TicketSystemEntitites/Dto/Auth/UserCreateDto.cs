using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Entitites.Dto.Auth
{
    public class UserCreateDto
    {
        public required string Email { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;

        public required string FirstName { get; set; } = string.Empty;
        public required string LastName { get; set; } = string.Empty;
    }
}
