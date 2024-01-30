using IdentityModel;

using IdentityServer4.Models;
using IdentityServer4.Services;

using System.Security.Claims;

namespace Auth.Application
{
    public class CustomProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.AddRange(new List<Claim>()
        {
            new Claim(JwtClaimTypes.Role, "admin")
        });

            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;

            return Task.CompletedTask;
        }
    }
}
