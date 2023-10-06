using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using zad1.Models;

namespace zad1.Services;

public class WeatherService : IWeatherService
{
    private readonly string key = "0an4CX67gG7TkhAUyMNsJH3JGgAbCAdI";
    private readonly string language = "pl-pl";
    
    public async Task<List<Location>> AutocompleteSearchAsync(string query)
    {
        using var client = new HttpClient();
        var response = await client.GetAsync($"http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={key}&q={query}&language={language}");

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Something went wrong");
        }
    
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Location>>(content);
    }

    public async Task<string> FetchLocationKeyAsync(string city)
    {
        using var client = new HttpClient();
        var response = client.GetAsync($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={key}&q={city}&language={language}");
        
        if (!response.Result.IsSuccessStatusCode)
        {
            throw new HttpRequestException("Something went wrong");
        }
        
        var content = await response.Result.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<List<Location>>(content)[0].Key;
    }

    public Task<DayForecast> FetchOneDayWeatherAsync(string city)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<DayForecast>> FetchTenDayWeatherAsync(string city)
    {
        throw new System.NotImplementedException();
    }

    public Task<HourForecast> FetchOneHourWeatherAsync(string city)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<HourForecast>> FetchTwelveHourWeatherAsync(string city)
    {
        throw new System.NotImplementedException();
    }
}