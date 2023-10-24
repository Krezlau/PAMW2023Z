using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using zad1.Services;

namespace zad1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly IWeatherService _weatherService;
    
    public MainWindowViewModel(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    private string _cityBoxText = "";

    public string CityBoxText
    {
        get => _cityBoxText;
        set
        {
            _cityBoxText = value;
            OnPropertyChanged();
        }
    }
    
    private string _resultText = "";

    public string ResultText
    {
        get => _resultText;
        set
        {
            _resultText = value;
            OnPropertyChanged();
        }
    }

    private Brush _resultColor = Brushes.Black;

    public Brush ResultColor
    {
        get => _resultColor;
        set
        {
            _resultColor = value;
            OnPropertyChanged();
        }
    }
    
    [RelayCommand]
    private async Task AutoCompleteCityName()
    {
        try
        {
            var cities = await _weatherService.AutocompleteSearchAsync(CityBoxText);
            DisplayResultText(string.Join('\n' ,cities.Select(c => c.LocalizedName)));
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    [RelayCommand]
    private async void FetchCityCode()
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBoxText);
            DisplayResultText(cityKey);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    [RelayCommand]
    private async void OneDayWeatherByCityCode()
    {
        try
        {
            var dayForecast = await _weatherService.FetchOneDayWeatherAsync(CityBoxText);
            var forecast = dayForecast.DailyForecasts[0];
            var text = $"Summary: {dayForecast.Headline.Text}\n" +
                       $"Temperature: {forecast.Temperature.Minimum.Value} - {forecast.Temperature.Maximum.Value} {forecast.Temperature.Minimum.Unit}\n" +
                       $"Day: {forecast.Day.IconPhrase}\n" +
                       $"Night: {forecast.Night.IconPhrase}\n" +
                       $"Precipitation: {forecast.Day.HasPrecipitation}\n" +
                       $"Mobile link: {forecast.MobileLink}\n" +
                       $"Link: {forecast.Link}";
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    [RelayCommand]
    private async void OneDayWeather()
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBoxText);
            var dayForecast = await _weatherService.FetchOneDayWeatherAsync(cityKey);
            var forecast = dayForecast.DailyForecasts[0];
            var text = $"Summary: {dayForecast.Headline.Text}\n" +
                       $"Temperature: {forecast.Temperature.Minimum.Value} - {forecast.Temperature.Maximum.Value} {forecast.Temperature.Minimum.Unit}\n" +
                       $"Day: {forecast.Day.IconPhrase}\n" +
                       $"Night: {forecast.Night.IconPhrase}\n" +
                       $"Precipitation: {forecast.Day.HasPrecipitation}\n" +
                       $"Mobile link: {forecast.MobileLink}\n" +
                       $"Link: {forecast.Link}";
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    [RelayCommand]
    private async void OneDayWeatherWithAutocomplete()
    {
        try
        {
            var cities = await _weatherService.AutocompleteSearchAsync(CityBoxText);
            if (cities.Count == 0) throw new Exception("No cities found");
            var cityKey = await _weatherService.FetchLocationKeyAsync(cities[0].LocalizedName);
            var dayForecast = await _weatherService.FetchOneDayWeatherAsync(cityKey);
            var forecast = dayForecast.DailyForecasts[0];
            var text = $"City: {cities[0].LocalizedName}\n" +
                       $"Summary: {dayForecast.Headline.Text}\n" +
                       $"Temperature: {forecast.Temperature.Minimum.Value} - {forecast.Temperature.Maximum.Value} {forecast.Temperature.Minimum.Unit}\n" +
                       $"Day: {forecast.Day.IconPhrase}\n" +
                       $"Night: {forecast.Night.IconPhrase}\n" +
                       $"Precipitation: {forecast.Day.HasPrecipitation}\n" +
                       $"Mobile link: {forecast.MobileLink}\n" +
                       $"Link: {forecast.Link}";
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    [RelayCommand]
    private async void FiveDaysWeather()
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBoxText);
            var dayForecast = await _weatherService.FetchFiveDaysWeatherAsync(cityKey);
            var forecasts= dayForecast.DailyForecasts;
            var text = $"City: {CityBoxText}\n" +
                       $"Summary: {dayForecast.Headline.Text}\n";
            text = forecasts.Aggregate(text,
                (current, forecast) => current +
                                       ($"{forecast.Date.ToShortDateString()}: {forecast.Temperature.Minimum.Value}" +
                                        $"{forecast.Temperature.Minimum.Unit} - {forecast.Temperature.Maximum.Value}" +
                                        $"{forecast.Temperature.Maximum.Unit}\n"));
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    
    [RelayCommand]
    private async void OneHourWeather() 
    { 
        try {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBoxText);
            var hourForecast = await _weatherService.FetchOneHourWeatherAsync(cityKey);
            var text = $"City: {CityBoxText}\n" +
                       $"{hourForecast.DateTime.ToShortTimeString()}: {hourForecast.Temperature.Value}" +
                       $"{hourForecast.Temperature.Unit} {hourForecast.IconPhrase}\n";
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }
    
    [RelayCommand]
    private async void TwelveHoursWeather() 
    { 
        try {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBoxText);
            var hourForecast = await _weatherService.FetchTwelveHourWeatherAsync(cityKey);
            var text = $"City: {CityBoxText}\n"; 
            text = hourForecast.Aggregate(text, (current, hourForecast) => current +
                       $"{hourForecast.DateTime.ToShortTimeString()}: {hourForecast.Temperature.Value}" +
                       $"{hourForecast.Temperature.Unit} {hourForecast.IconPhrase}\n");
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    private void DisplayResultText(string text)
    {
        ResultColor = Brushes.Black;
        ResultText = text;
    }

    private void DisplayErrorText(string text)
    {
        ResultColor = Brushes.Red;
        ResultText = text;
    }
}