using System.Text;
using System.Text.Json;

namespace Practice;

public class RandomNumber
{
    public static int GetHttpRandomNumber(int minNumber, int maxNumber)
    {
        var request = new HttpRequestMessage()
        {
            RequestUri =
                new Uri(
                    $"https://lucky-random.ru/modules/nrand/api.php?count=1&min={minNumber}&max={maxNumber}&unique=1"),
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

    public static int GetNetRandomNumber(int minNumber, int maxNumber)
    {
        var random = new Random();
        return random.Next(minNumber, maxNumber);
    }
}