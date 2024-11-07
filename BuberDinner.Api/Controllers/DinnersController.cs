using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/dinners")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinner()
    {
        return Ok("Hello");
    }
}
