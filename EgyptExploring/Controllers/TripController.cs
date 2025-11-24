using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using EgyptExploring.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EgyptExploring.Controllers
{
    [Authorize] 
    public class TripController : Controller
    {
        private readonly ITripRepository _tripRepository;

        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

       
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            List<Trip> trips = _tripRepository.Read();
            return View(trips);
        }

        [AllowAnonymous]
        public IActionResult TripDetails(int id)
        {
            Trip trip = _tripRepository.GetOne(id);
            return View(trip);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AddTrip()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTrip(TripViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("GetAll");
        }
    }
}
