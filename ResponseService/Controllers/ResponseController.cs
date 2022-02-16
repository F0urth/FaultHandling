namespace ResponseService.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ResponseController : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetResponse(int id)
    {
        var next = Random.Shared.Next(1, 101);

        if (id < next)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("--> Failure Generate 500");
            Console.ResetColor();

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("--> Success Generate 200");
        Console.ResetColor();
        return Ok(id);
    }
}