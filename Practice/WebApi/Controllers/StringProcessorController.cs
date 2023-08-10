using Microsoft.AspNetCore.Mvc;
using Practice;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StringProcessorController : ControllerBase
{
    private readonly ILogger<StringProcessorController> _logger;
    private readonly StringProcessor _stringProcessor;

    public StringProcessorController(ILogger<StringProcessorController> logger, StringProcessor stringProcessor, StringProcessorConfig config)
    {
        _logger = logger;
        _stringProcessor = stringProcessor;
        _config = config;
    }

    private static int currentCountConnection = 0;
    private readonly StringProcessorConfig _config;

    [HttpGet(Name = "GetWeatherForecast")]
    public ObjectResult GetProcessedString(string inputString, SortType sortType)
    {
        currentCountConnection++;
        Console.WriteLine(currentCountConnection);
        if (currentCountConnection > _config.ParallelLimit)
        {
            currentCountConnection--;
            return StatusCode(503, "");
        }

        try
        {
            var result = _stringProcessor.Run(inputString, sortType);
            currentCountConnection--;
            return StatusCode(200, result);
        }
        catch (ArgumentException e)
        {
            currentCountConnection--;
            return StatusCode(400, $"{e.Message}");
        }
    }
}