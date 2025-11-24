using EgyptExploring.Models;
using EgyptExploring.Repositories;
using EgyptExploring.RepositryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EgyptExploring.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityRepositry cityRepository;
        public CityController(ICityRepositry _cityRepository)
        {
            cityRepository= _cityRepository;
        }
        [HttpGet]
        public IActionResult GetAll() {
            List<City> cities = cityRepository.Read();
        return View("GetAllCities",cities);
            
        }

        

    }
}
