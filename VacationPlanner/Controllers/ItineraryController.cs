
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

        
        public IActionResult Itinerary()
        {
            var newItineraryViewModel = new ItineraryViewModel();
            return View( newItineraryViewModel );
        }
        

        [HttpPost]
        public IActionResult Itinerary(string[] destination)
        {
            if (!ModelState.IsValid) return Redirect("/Itinerary/Results");


            int lastCity = _context.City.Max(i => i.ID);
            foreach (var item in destination)
            {

                _context.Itinerary.Add(new Itinerary{Location = item, CityID = lastCity});
                
            }

            
            _context.SaveChanges();
            return Redirect("/Itinerary/AddItinerary");
        }

        

        
       
    }
}



