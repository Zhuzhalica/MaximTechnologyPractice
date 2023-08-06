using System.Text;
using System.Text.Json;

namespace Practice.Random;

public class RandomNumber : IRandomNumber
{
    private readonly StringProcessorConfig config;

    public RandomNumber(StringProcessorConfig config)
    {
        this.config = config;
    }

    public int GetHttpRandomNumber(int minNumber, int maxNumber)
    {
        var request = new HttpRequestMessage()
        {
            RequestUri =
                new Uri($"{config.RandomApi}/api.php?count=1&min={minNumber}&max={maxNumber}&unique=1)"),
            Method = HttpMethod.Get
        };

        var response = new HttpClient().Send(request);
        if (response.IsSuccessStatusCode)
        {
            var responseString = response.Content.ReadAsStringAsync().Result;
            return int.Parse(responseString!.Split(" ")[0]);
        }

        return GetNetRandomNumber(minNumber, maxNumber);
    }

    public int GetNetRandomNumber(int minNumber, int maxNumber)
    {
        var random = new System.Random();
        return random.Next(minNumber, maxNumber);
    }
}