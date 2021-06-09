using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }
    }
}