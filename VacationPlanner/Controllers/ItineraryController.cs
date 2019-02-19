using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacationPlanner.ViewModels;
using VacationPlanner.Models;
using VacationPlanner.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis;

namespace VacationPlanner.Controllers
{
    public class ItineraryController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public ItineraryController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            var itineraryViewModel = new ItineraryViewModel();
            return View(itineraryViewModel);

        }


        [HttpPost]
        public IActionResult Result(Itinerary location)
        {

            return View(location);

        }


        
        public IActionResult Itinerary()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Itinerary(string[] destination)
        {
            foreach (var item in destination)
            {
                _context.Itinerary.Add(new Itinerary{LocationName = item});//error
            }

            _context.SaveChanges();
            return Redirect("/Itinerary/AddItinerary");
        }

        public IActionResult AddItinerary()
        {
            IList<Itinerary> itineraries = _context.Itinerary.Include( i => i.LocationName ).ToList();

            return View( itineraries );
        }
       
    }
}



