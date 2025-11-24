using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using EgyptExploring.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EgyptExploring.Controllers
{
    public class BookingController : Controller 
    {
        
        private readonly IBookinRepository _BookingRepository;
        private readonly ITripRepository _TripRepository;
        public BookingController( IBookinRepository bookinRepository , ITripRepository tripRepository)
        {
            _BookingRepository = bookinRepository;
            _TripRepository = tripRepository;
        }

        [HttpGet]
        public IActionResult MakeBooking(int id) { 
        Trip trip = _TripRepository.GetOne(id);
        BookingViewModel viewModel = new BookingViewModel();
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            viewModel.PricePerOne = trip.TripPrice;
            viewModel.TripId = trip.TripId;
            viewModel.Title = trip.TripName;
            viewModel.UserId = userId;

            return View(viewModel);
        
        }

        [HttpPost]
        public IActionResult MakeBooking(BookingViewModel viewModel) {
            if (ModelState.IsValid) { 
            viewModel.TotalPrice= viewModel.PricePerOne*viewModel.NumberOfPersons;
                Booking booking = new Booking();
                booking.TotalPrice=viewModel.TotalPrice;
                booking.NumberOfPersons=viewModel.NumberOfPersons;
                booking.TripId=viewModel.TripId;
                booking.UserId=viewModel.UserId;
                booking.Date=DateTime.Now;
                _BookingRepository.Create(booking);
                _BookingRepository.Save();
                return RedirectToAction("MyBooking",booking.UserId);
            }  
            return View(viewModel);
        

        }
        [HttpGet]
        public IActionResult MyBooking(int id ) {
            id = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Booking>bookings= _BookingRepository.GetAllById(id);
            return View(bookings);

        }

 



    }
}
