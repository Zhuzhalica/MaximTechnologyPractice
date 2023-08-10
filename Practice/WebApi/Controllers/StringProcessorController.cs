using Microsoft.AspNetCore.Mvc;
using Practice;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StringProcessorController : ControllerBase
{
    private readonly ILogger<StringProcessorController> _logger;
    private readonly StringProcessor _stringProcessor;
    private readonly StringProcessorConfig _config;


    public StringProcessorController(ILogger<StringProcessorController> logger, StringProcessor stringProcessor,
        StringProcessorConfig config)
    {
        _logger = logger;
        _stringProcessor = stringProcessor;
        _config = config;
    }
    

    [HttpGet(Name = "GetWeatherForecast")]
    public ObjectResult GetProcessedString(string inputString, SortType sortType)
    {
        if (!_config.SetConnect())
            return StatusCode(503, "");
        
        int statusCode;
        string result;

        try
        {
            result = _stringProcessor.Run(inputString, sortType);
            statusCode = 200;
        }
        catch (ArgumentException e)
        {
            result = e.Message;
            statusCode = 400;
        }

        _config.CloseConnect();
        return StatusCode(statusCode, result);
    }
}