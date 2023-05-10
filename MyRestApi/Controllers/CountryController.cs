using Microsoft.AspNetCore.Mvc;

namespace MyRestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController : ControllerBase
{
    

    private readonly ILogger<CountryController> _logger;

    public CountryController(ILogger<CountryController> logger)
    {
        _logger = logger;
    }

        public struct Country
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class City
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int CountryId { get; set; }
        }
        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get()
        {
            var countries = new List<Country>
            {
                new Country { Id = 1, Name = "United States" },
                new Country { Id = 2, Name = "Canada" },
                new Country { Id = 3, Name = "United Kingdom" },
                 new Country { Id = 4, Name = "France" },
                 new Country { Id = 4, Name = "Germany" },
                 new Country { Id = 4, Name = "Australia" },
                 new Country { Id = 4, Name = "Japan" },
                // Add more countries as needed
            };

            return Ok(countries);
        }
        [HttpGet("{countryId}/cities")]
public ActionResult<IEnumerable<City>> GetCitiesByCountryId(int countryId)
{
    var cities = new List<City>
    {
        new City { Id = 1, Name = "New York", CountryId = 1 },
        new City { Id = 2, Name = "Los Angeles", CountryId = 1 },
        new City { Id = 3, Name = "Toronto", CountryId = 2 },
        new City { Id = 4, Name = "Vancouver", CountryId = 2 },
        new City { Id = 5, Name = "London", CountryId = 3 },
        new City { Id = 6, Name = "Birmingham", CountryId = 3 },
        // Add more cities as needed
    };

    var selectedCities = cities.FindAll(city => city.CountryId == countryId);
    if (selectedCities.Count == 0)
    {
        return NotFound("No cities found for the given country ID.");
    }

    return Ok(selectedCities);
}
    
}
