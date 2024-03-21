using Microsoft.AspNetCore.Mvc;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("AuthController")]
    public class AuthController : ControllerBase
    {
        //https://www.youtube.com/watch?v=1js5U3gWamg
        //54:50
        public AuthController()
        {
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}