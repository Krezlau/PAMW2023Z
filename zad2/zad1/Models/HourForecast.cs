using System;

namespace zad1.Models;
public class HourForecast
{
    public DateTime DateTime { get; set; }
    public int EpochDateTime { get; set; }
    public int WeatherIcon { get; set; }
    public string IconPhrase { get; set; }
    public bool HasPrecipitation { get; set; }
    public string PrecipitationType { get; set; }
    public string PrecipitationIntensity { get; set; }
    public bool IsDaylight { get; set; }
    public HourTemperature Temperature { get; set; }
    public int PrecipitationProbability { get; set; }
    public string MobileLink { get; set; }
    public string Link { get; set; }
}

public class HourTemperature
{
    public double Value { get; set; }
    public string Unit { get; set; }
    public int UnitType { get; set; }
}

