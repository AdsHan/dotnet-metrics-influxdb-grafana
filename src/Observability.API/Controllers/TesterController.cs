using Microsoft.AspNetCore.Mvc;

namespace Observability.API.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiController]
    public class TesterController : ControllerBase
    {
        [HttpGet("ok")]
        public async Task<IActionResult> ReturnOk()
        {
            return Ok();
        }

        [HttpGet("bad-request")]
        public async Task<IActionResult> ReturnBadRequest()
        {
            return BadRequest();
        }

        [HttpGet("unauthorized")]
        public async Task<IActionResult> ReturnUnauthorized()
        {
            return Unauthorized();
        }

        [HttpPost("created")]
        public async Task<IActionResult> ReturnCreated()
        {
            return CreatedAtAction(nameof(ReturnCreated), new { id = 1 }, new { });
        }

        [HttpGet("exception")]
        public async Task<IActionResult> ReturnException()
        {
            throw new Exception("Exception");
        }
    }
}
