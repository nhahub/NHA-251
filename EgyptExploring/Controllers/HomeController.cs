using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EgyptExploring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICityRepositry cityRepositry;
        public HomeController( ICityRepositry _cityrepository)
        {
            cityRepositry = _cityrepository;
        }
        [HttpGet]


        [HttpGet]
        public IActionResult AboutUs() { 
        
              return View();  
        }

        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            List<City> items = cityRepositry.Read()
                                .OrderBy(p => p.CityName)            
                                .Skip((page - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            int totalItems = cityRepositry.Read().Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;

            return View("Index" , items);
        }


    }
}
