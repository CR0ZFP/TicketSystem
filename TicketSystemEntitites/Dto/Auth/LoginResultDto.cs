using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Entitites.Dto.Auth
{
    public class LoginResultDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiration { get; set; }
    }
}
