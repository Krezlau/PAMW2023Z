using System.Collections.Generic;
using System.Threading.Tasks;
using zad1.Models;

namespace zad1.Services;

public class WeatherService : IWeatherService
{
    private readonly string key = "0an4CX67gG7TkhAUyMNsJH3JGgAbCAdI";
    private readonly string language = "pl-pl";
    
    public Task<List<Location>> AutocompleteSearchAsync(string query)
    {
        throw new System.NotImplementedException();
    }

    public Task<string> FetchLocationKeyAsync(string city)
    {
        throw new System.NotImplementedException();
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