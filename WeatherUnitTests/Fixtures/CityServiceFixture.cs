using WeatherApiDomain.Entity.Dto;

namespace WeatherUnitTests.Fixtures;

public class CityServiceFixture
{
    
    public static List<CityResponseDto> CityList() => new()
    {
        new CityResponseDto { Name = "Santos" },
        new CityResponseDto { Name = "São Paulo" },
        new CityResponseDto { Name = "Rio Grande" },
        new CityResponseDto { Name = "Pelotas" }
    };

    public static Guid? CityId()
    {
        return new Guid("f3cfd7de-bde3-4ca5-9aca-e6baf2856820");
    }
    
    
}