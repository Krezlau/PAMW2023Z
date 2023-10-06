using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using zad1.Services;

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
        // autocomplete miasta
        try
        {
            var cities = await _weatherService.AutocompleteSearchAsync(CityBox.Text);
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.Black;
            ResultTextBlock.Text = string.Join('\n' ,cities.Select(c => c.LocalizedName));
        }
        catch (Exception exception)
        {
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            ResultTextBlock.Text = exception.Message;
        }
    }

    private async void EndpointTwoOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var cityKey = await _weatherService.FetchLocationKeyAsync(CityBox.Text);
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.Black;
            ResultTextBlock.Text = cityKey;
        }
        catch (Exception exception)
        {
            ResultTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            ResultTextBlock.Text = exception.Message;
        }
    }

    private void EndpointThreeOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EndpointFourOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EndpointFiveOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EndpointSixOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EndpointSevenOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}