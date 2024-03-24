using Microsoft.AspNetCore.Mvc;

namespace LogisticsСontrolSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        public Authenticator authenticator;

        public AuthenticatorController(Authenticator authenticator)
        {
            this.authenticator = authenticator;
        }

        [HttpGet]
        public ActionResult Get(string username, string password)
        {
            Guid? token = authenticator.Authentication(username, password);

            if (token != null)
            {
                return Ok(token);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
