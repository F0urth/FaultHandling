namespace RequestService.Controllers;

using Microsoft.AspNetCore.Mvc;
using Policies;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> MakeRequest(
        [FromRoute]int id,
        [FromServices] ClientPolicy clientPolicy)
    {
        var client = new HttpClient();
        // var response = await client.GetAsync($"http://localhost:5162/api/Response/{id}");

        var response = await clientPolicy.ImmidateHttpRetryPolicy.ExecuteAsync(
            () => client.GetAsync($"http://localhost:5162/api/Response/{id}"));

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