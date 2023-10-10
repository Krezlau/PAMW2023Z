using System.Linq;
using System.Windows;
using zad1.Services;
using Exception = System.Exception;

namespace zad1;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IWeatherService _weatherService;
    
    public MainWindow()
    {
        InitializeComponent();
        _weatherService = new WeatherService();
    }

    private async void AutoCompleteCityNameOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var cities = await _weatherService.AutocompleteSearchAsync(CityBox.Text);
            DisplayResultText(string.Join('\n' ,cities.Select(c => c.LocalizedName)));
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    private async void FetchCityCodeOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBox.Text);
            DisplayResultText(cityKey);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }

    private async void OneDayWeatherByCityCodeOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var dayForecast = await _weatherService.FetchOneDayWeatherAsync(CityBox.Text);
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

    private async void OneDayWeatherOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBox.Text);
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

    private async void OneDayWeatherWithAutocompleteOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var cities = await _weatherService.AutocompleteSearchAsync(CityBox.Text);
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

    private async void FiveDaysWeatherOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBox.Text);
            var dayForecast = await _weatherService.FetchFiveDaysWeatherAsync(cityKey);
            var forecasts= dayForecast.DailyForecasts;
            var text = $"City: {CityBox.Text}\n" +
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

    
    private async void OneHourWeatherOnClick(object sender, RoutedEventArgs e) 
    { 
        try {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBox.Text);
            var hourForecast = await _weatherService.FetchOneHourWeatherAsync(cityKey);
            var text = $"City: {CityBox.Text}\n" +
                       $"{hourForecast.DateTime.ToShortTimeString()}: {hourForecast.Temperature.Value}" +
                       $"{hourForecast.Temperature.Unit} {hourForecast.IconPhrase}\n";
            DisplayResultText(text);
        }
        catch (Exception exception)
        {
            DisplayErrorText(exception.Message);
        }
    }
    
    private async void TwelveHoursWeatherOnClick(object sender, RoutedEventArgs e) 
    { 
        try {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBox.Text);
            var hourForecast = await _weatherService.FetchTwelveHourWeatherAsync(cityKey);
            var text = $"City: {CityBox.Text}\n"; 
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
        ResultTextBlock.Foreground = System.Windows.Media.Brushes.Black;
        ResultTextBlock.Text = text;
    }

    private void DisplayErrorText(string text)
    {
        ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
        ResultTextBlock.Text = text;
    }
}