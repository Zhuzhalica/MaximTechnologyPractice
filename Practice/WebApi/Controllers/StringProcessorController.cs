using Microsoft.AspNetCore.Mvc;
using Practice;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StringProcessorController : ControllerBase
{
    private readonly ILogger<StringProcessorController> _logger;
    private readonly StringProcessor _stringProcessor;

    public StringProcessorController(ILogger<StringProcessorController> logger, StringProcessor stringProcessor)
    {
        _logger = logger;
        _stringProcessor = stringProcessor;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ObjectResult GetProcessedString(string inputString, SortType sortType)
    {
        try
        {
            return StatusCode(200, _stringProcessor.Run(inputString, sortType));
        }
        catch (ArgumentException e)
        {
            return StatusCode(400, $"{e.Message}");
        }
    }
}