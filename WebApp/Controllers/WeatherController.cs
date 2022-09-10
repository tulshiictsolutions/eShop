using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async  Task<IActionResult> Forecast()
        {
            List<WeatherForecastModel>? models;
            using (var client = _httpClientFactory.CreateClient("APIEndPoint"))
            {
                models = await client.GetFromJsonAsync<List<WeatherForecastModel>>("/weatherforecast");                

            }
            return View(models);
        }
    }
}
