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

    private void EnpointOneOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void EndpointTwoOnClick(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
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