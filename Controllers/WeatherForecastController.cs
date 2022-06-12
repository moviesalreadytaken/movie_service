using Microsoft.AspNetCore.Mvc;

namespace movie.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<String> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new String('a', index))
        .ToArray();
    }
}
