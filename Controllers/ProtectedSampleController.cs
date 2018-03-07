using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProtectedSampleController : Controller
    {
        public IActionResult Get()
        {
            return Ok(new
            {
                Id = 1,
                Title = "Hello from My Protected Controller!",
                Username = this.User.Identity.Name
            });
        }
    }
}