using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models {
    public class User : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
    }
}