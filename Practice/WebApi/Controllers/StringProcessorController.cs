using Microsoft.AspNetCore.Mvc;
using Practice;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StringProcessorController : ControllerBase
{
    private readonly ILogger<StringProcessorController> _logger;

    public StringProcessorController(ILogger<StringProcessorController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ObjectResult GetProcessedString(string inputString, SortType sortType)
    {
        try
        {
            return StatusCode(200, StringProcessor.Run(inputString, sortType));
        }
        catch (ArgumentException e)
        {
            return StatusCode(400, $"{e.Message}");
        }
    }
}