using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceInvocation.Controllers
{
    [ApiController]
    public class DaprController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DaprController> _logger;

        public DaprController(ILogger<DaprController> logger)
        {
            _logger = logger;
        }
        //dapr 配置 dapr run --app-id serviceinvocation --app-port 5000 --dapr-http-port 13501 -- dotnet run
        //请求地址
        //:13501/v1.0/invoke/serviceinvocation/method/api/weather
        //:5000/api/weather
        [HttpGet("/api/weather")]
        public IEnumerable<WeatherForecast> GetWeather()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/hello")]
        public IActionResult GetHello(string what)
        {
            return Ok($"hello {what}");
        }
    }
}
