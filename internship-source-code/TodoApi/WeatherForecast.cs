namespace TodoApi;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 10;

    public string? Summary { get; set; }
}
