namespace RequestService.Controllers;

using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> MakeRequest([FromRoute]int id)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"http://localhost:5162/api/Response/{id}");

        if (response.IsSuccessStatusCode)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("--> Generate Success!!!");
            Console.ResetColor();
            return Ok();
        }

        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("--> Generate Failure!!!");
        Console.ResetColor(); 
        
        return StatusCode(StatusCodes.Status500InternalServerError);

    }
}