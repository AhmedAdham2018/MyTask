using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class CustomerManagerExtensions
    {

        public static async Task<Customer> FindByEmailFromClaimsPrincipals(this UserManager<Customer> input , ClaimsPrincipal customer)
        {
                var email = customer?.Claims?.FirstOrDefault(
                     x => x.Type == ClaimTypes.Email)?.Value;
                return await input.Users.SingleOrDefaultAsync(x => x.Email == email);     
        }
    }
}