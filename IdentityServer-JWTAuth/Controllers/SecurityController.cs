using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer_JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public void Login([FromBody] string value)
        {

        }
        [HttpPost]
        [AllowAnonymous]
        public void Signup([FromBody] string value)
        {

        }
        public async Task<string> GenerateJWT()
        {
            return "";
        }
    }
}
