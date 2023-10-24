using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using zad1.Models;

namespace zad1.Services;

public class WeatherService : IWeatherService
{
    private readonly string key = "acGJa4US0KUmb0U5dZfzguWMLvRzSAbC";
    private readonly string language = "pl-pl";
    
    public async Task<List<Location>> AutocompleteSearchAsync(string query)
    {
        var content = await FetchResponseFromApi($"http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={key}&q={query}&language={language}");
        return JsonSerializer.Deserialize<List<Location>>(content);
    }

    public async Task<string> FetchLocationKeyAsync(string city)
    {
        var content = await FetchResponseFromApi($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={key}&q={city}&language={language}");
        return JsonSerializer.Deserialize<List<Location>>(content)[0].Key;
    }

    public async Task<DayForecast> FetchOneDayWeatherAsync(string city)
    {
        var content = await FetchResponseFromApi($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{city}?apikey={key}&language={language}");
        return JsonSerializer.Deserialize<DayForecast>(content);
    }

    public async Task<DayForecast> FetchFiveDaysWeatherAsync(string city)
    {
        var content = await FetchResponseFromApi($"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{city}?apikey={key}&language={language}");
        return JsonSerializer.Deserialize<DayForecast>(content);
    }

    public async Task<HourForecast> FetchOneHourWeatherAsync(string city)
    {
        var content = await FetchResponseFromApi($"http://dataservice.accuweather.com/forecasts/v1/hourly/1hour/{city}?apikey={key}&language={language}");
        return JsonSerializer.Deserialize<List<HourForecast>>(content)[0];
    }

    public async Task<List<HourForecast>> FetchTwelveHourWeatherAsync(string city)
    {
        var content = await FetchResponseFromApi($"http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/{city}?apikey={key}&language={language}");
        return JsonSerializer.Deserialize<List<HourForecast>>(content);
    }
    
    private async Task<string> FetchResponseFromApi(string url)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync(url);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"{response.StatusCode}: Something went wrong");
        }
        
        return await response.Content.ReadAsStringAsync();
    }
}