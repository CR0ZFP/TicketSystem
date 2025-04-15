using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Entitites.Entities
{
    public class AppUser : IdentityUser
    {
        [StringLength(200)]
        public required string GivenName { get; set; } = string.Empty;
        [StringLength(200)]
        public required string FamilyName { get; set; } = string.Empty;
    }
}
