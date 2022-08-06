using Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public string DisplayName { get ; set ; } = string.Empty;
        public string Photo { get ; set ; } = string.Empty;
    }
}
