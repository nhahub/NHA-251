using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace EgyptExploring.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly ICityRepositry _cityRepositry;
        public DestinationController(IDestinationRepository destinationRepository, ICityRepositry cityRepositry)
        {
            _destinationRepository = destinationRepository;
            _cityRepositry = cityRepositry;
        }
        public IActionResult GetAll(int cityId)
        {
            City city = _cityRepositry.GetOne(cityId);

            if (city == null)
            {
                return NotFound();
            }

            ViewBag.CityName = city.CityName;  

            var destinations = city.Destinations ?? new List<Destination>();
            return View("Index", destinations); 
        }




        public IActionResult DestinationDetails(int id)
        {
            Destination destination = _destinationRepository.GetOne(id);
            return View(destination);
        }
    }
}
