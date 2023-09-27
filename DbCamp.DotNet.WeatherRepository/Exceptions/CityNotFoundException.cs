namespace WeatherApi.Exceptions;

public class CityNotFoundException : Exception
{
    public CityNotFoundException(string cityName)
        : base($"City with the name '{cityName}' was not found.")
    {
    }
}