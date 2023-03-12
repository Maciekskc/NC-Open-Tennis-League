using Microsoft.AspNetCore.Identity;

namespace Persistance.Models;

public class ApplicationUser : IdentityUser
{
    public TennisPlayer? Player { get; set; }
}
