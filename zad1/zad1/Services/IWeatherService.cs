using System.Collections.Generic;
using System.Threading.Tasks;
using zad1.Models;

namespace zad1.Services;

public interface IWeatherService
{
    Task<List<Location>> AutocompleteSearchAsync(string query);
    Task<string> FetchLocationKeyAsync(string city);
    Task<DayForecast> FetchOneDayWeatherAsync(string city);
    Task<List<DayForecast>> FetchTenDayWeatherAsync(string city);
    Task<HourForecast> FetchOneHourWeatherAsync(string city);
    Task<List<HourForecast>> FetchTwelveHourWeatherAsync(string city);
}