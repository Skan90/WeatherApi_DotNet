using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherApiController.Controllers;
using WeatherApiDomain.Entity.Dto;
using WeatherApiDomain.Interfaces.Services;
using static WeatherUnitTests.Fixtures.CityServiceFixture;

namespace WeatherUnitTests.Systems.Controllers;

public class CityServiceTest
{
    
    [Fact]
    public async Task GetAll_OnSuccess_ReturnStatusCode200()
    {
        // Arrange
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetAllAsync())
            .ReturnsAsync(CityList()!);
        
        var sut = new CityController(mockCityService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetAll().ConfigureAwait(false);

        // Assert
        result.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task GetAll_OnSuccess_InvokesCityServiceExactlyOnce()
    {
        // Arrange
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetAllAsync())
            .ReturnsAsync(CityList()!);
        
        var sut = new CityController(mockCityService.Object);

        // Act
        await sut.GetAll().ConfigureAwait(false);

        // Assert
        mockCityService.Verify(
            service => service.GetAllAsync(),
            Times.Once);
    }
    
    [Fact]
    public async Task GetAll_OnSuccess_ReturnsListOfCities()
    {
        // Arrange
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetAllAsync())
            .ReturnsAsync(CityList()!);
        
        var sut = new CityController(mockCityService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetAll().ConfigureAwait(false);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<List<CityResponseDto>>();
    }
    
    [Fact]
    public async Task GetAll_OnFailure_Returns204NoContent()
    {
        // Arrange
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetAllAsync())
            .ReturnsAsync(new List<CityResponseDto>());
        
        var sut = new CityController(mockCityService.Object);

        // Act
        var result = (NoContentResult)await sut.GetAll().ConfigureAwait(false);

        // Assert
        result.Should().BeOfType<NoContentResult>();
        result.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public async Task GetIdByCityName_OnSuccess_ReturnsStatusCodeOk200()
    {
        // Arrange
        var cityName = "Pelotas";
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetIdByCityName(cityName))
            .ReturnsAsync(CityId());
        
        var sut = new CityController(mockCityService.Object);

        // Act
        var result = (OkObjectResult)await sut.GetIdByCityName(cityName).ConfigureAwait(false);

        // Assert
        result.StatusCode.Should().Be(200);
    }
    [Fact]
    public async Task GetIdByCityName_OnSuccess_InvokesCityServiceExactlyOnce()
    {
        // Arrange
        var cityName = "Pelotas";
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetIdByCityName(cityName))
            .ReturnsAsync(CityId());
        
        var sut = new CityController(mockCityService.Object);

        // Act
        await sut.GetIdByCityName(cityName).ConfigureAwait(false);

        // Assert
        mockCityService.Verify(
            service => service.GetIdByCityName(cityName),
            Times.Once);
    }
    
    [Fact]
    public async Task GetIdByCityName_OnFailure_ReturnsStatusCode204NoContent()
    {
        // Arrange
        var cityName = "Pelotas";
        var mockCityService = new Mock<ICityService>();
        mockCityService
            .Setup(service => service.GetIdByCityName(cityName))
            .ReturnsAsync(Guid.Empty);
        
        var sut = new CityController(mockCityService.Object);

        // Act
        var result = (NotFoundObjectResult)await sut.GetIdByCityName(cityName).ConfigureAwait(false);

        // Assert
        result.Should().BeOfType<NotFoundObjectResult>();
        result.StatusCode.Should().Be(404);
        result.Value.Should().Be("City with the given name was not found.\n" +
                                          "Check the name and try again.");
    }
    
}
