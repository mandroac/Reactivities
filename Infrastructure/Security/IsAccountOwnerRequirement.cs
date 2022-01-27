using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class IsAccountOwnerRequirement : IAuthorizationRequirement
    {

    }

    public class IsAccountOwnerRequirementHandler : AuthorizationHandler<IsAccountOwnerRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IsAccountOwnerRequirementHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAccountOwnerRequirement requirement)
        {
            var loggedInUsername = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var requestUsername = _httpContextAccessor.HttpContext.Request.RouteValues?
                .SingleOrDefault(x => x.Key == "username").Value?.ToString();

            if(loggedInUsername == null || requestUsername == null || loggedInUsername != requestUsername) 
            {
                return Task.CompletedTask;
            }
            else {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
        }
    }
}