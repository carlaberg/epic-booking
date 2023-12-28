using System.Security.Claims;
using Epic_Booking.Models;
using Microsoft.AspNetCore.Authorization;

namespace Epic_Booking.Services
{
    public class BookingAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, Booking>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                               SameAuthorRequirement requirement,
                                               Booking resource)
        {
            var uId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (uId == resource.CreatorId)
            {
                context?.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}

public class SameAuthorRequirement : IAuthorizationRequirement { }