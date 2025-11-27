using EgyptExploring.Models;
using EgyptExploring.Repositories;
using EgyptExploring.RepositryInterfaces;
using EgyptExploring.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EgyptExploring.Controllers
{

    [Authorize(Roles =("Admin"))]
    public class AdminController : Controller
    {
        private readonly IAppUserRepository _userRepository;
        private readonly ITripRepository _TripRepository;
        private readonly ICityRepositry _cityRepository;
        private readonly UserManager<AppUser> _userManager;
        public AdminController(IAppUserRepository appUserRepository, ITripRepository tripRepository , ICityRepositry cityRepository , UserManager<AppUser> UserManager)
        {
            _userRepository = appUserRepository;
            _TripRepository = tripRepository;
            _cityRepository = cityRepository;
            _userManager = UserManager;
        }
        public IActionResult AdminPanel()
        {
            return View();
        }


        public IActionResult GetAllUsers()
        {
            List<AppUser> users = _userRepository.Read().ToList();
            return View(users);

        }

        public IActionResult GetAllTrips()
        {
            List<Trip> trips = _TripRepository.Read().ToList();
            return View(trips);
        }
        public IActionResult DeleteTrip(int id)
        {
             _TripRepository.Delete(id);
            _TripRepository.Save();
            return RedirectToAction("GetAllTrips", "Admin");
        }

        [HttpGet]
        public IActionResult EditTrip(int id)
        {
            Trip trip = _TripRepository.GetOne(id);

            List<City> cities = _cityRepository.Read().ToList();
            ViewBag.Cities = new SelectList(cities, "CityId", "CityName", trip.CityId);

            return View(trip);
        }


        [HttpPost]
        public IActionResult EditTrip(Trip trip)
        {

            _TripRepository.Update(trip);
            _TripRepository.Save();
            return RedirectToAction("GetAllTrips", "Admin");
        }

        [HttpGet]
        public IActionResult AddTrip() { 
        List<City> cities = _cityRepository.Read().ToList();
            SelectList CitiesForView = new SelectList(cities, "CityId", "CityName");
            ViewData["Cities"] = CitiesForView;
            return View();
        }
        [HttpPost]
        public IActionResult AddTrip(TripViewModel tripViewModel) {
            if (ModelState.IsValid)
            {
                Trip trip = new Trip();
                trip.TripName = tripViewModel.Name;
                trip.TripDescription = tripViewModel.Description;
                trip.TripPrice = tripViewModel.Price;
                trip.CityId = tripViewModel.CityId;
                _TripRepository.Create(trip);
                _TripRepository.Save();
                return RedirectToAction("GetAllTrips", "Admin");
            }
            return View("AddTrip",tripViewModel);


            

        
        }

            public async Task<IActionResult> LockUser(int Id) {
        
            AppUser User= _userRepository.GetOne(Id);
            await _userManager.SetLockoutEndDateAsync(User, DateTimeOffset.MaxValue);
           return RedirectToAction("GetAllUsers");

        }
            public async Task<IActionResult> UnLockUser(int Id) {
        
            AppUser User= _userRepository.GetOne(Id);
            await _userManager.SetLockoutEndDateAsync(User, null);
            return RedirectToAction("GetAllUsers");

        }

    }
}
