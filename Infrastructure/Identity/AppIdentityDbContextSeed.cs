using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<Customer> userManager)
        {
            if (!userManager.Users.Any())
            {
                var customer = new Customer
                {
                    Name = "Ahmed",
                    Email = "ahmed@test.com",
                    UserName = "ahmed@test.com",
                };

                await userManager.CreateAsync(customer, "Pa$$w0rd");
            }
        }
    }
}