using System.Security.Claims;
using Auth.Persistence.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Auth.Extensions;
using System.Threading.Tasks;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = CustomRoles.Admin)]
    public class AdminProtectedSampleController : Controller
    {
        private readonly IUsersService _usersService;

        public AdminProtectedSampleController(IUsersService usersService)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));
        }

        public async Task<IActionResult> Get()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var userDataClaim = claimsIdentity.FindFirst(ClaimTypes.UserData);
            var userId = userDataClaim.Value;

            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Admin Api Controller!",
                Username = this.User.Identity.Name,
                UserData = userId,
                TokenSerialNumber = await _usersService.GetSerialNumberAsync(int.Parse(userId)).ConfigureAwait(false)
            });
        }
    }
}