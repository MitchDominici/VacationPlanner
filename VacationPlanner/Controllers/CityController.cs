﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VacationPlanner.Data;
using VacationPlanner.Models;
using VacationPlanner.ViewModels;

namespace VacationPlanner.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CityController( ApplicationDbContext dbContext )
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            var cityDatesViewModel = new CityViewModel();
            return View( cityDatesViewModel );

        }


        [HttpPost]
        public IActionResult AddCity( City CityName )
        {
            if (!ModelState.IsValid) return View();
            var city = CityName.Name;
            _context.City.Add( CityName );
            _context.SaveChanges();

            
            return RedirectToAction("Result", new {Name = CityName.Name});

        }

        [HttpGet]
        public IActionResult Result(City results)
        {
            return View(results);
        }

        public IActionResult ViewCities()
        {
            IList<City> cities = _context.City.Include( c => c.Name ).ToList();

            return View( cities );
        }

        
        public IActionResult RemoveCities()
        {
            IList<City> cities = _context.City.Include( c => c.Name ).ToList();

            return View( cities );
        }

        [HttpPost]
        public IActionResult RemoveCities(int [] cityIds)
        {
            foreach (int cityId in cityIds)
            {
                var theCity = _context.City.Single(c => c.ID == cityId);
                _context.City.Remove(theCity);
            }

            _context.SaveChanges();

            return RedirectToAction("ViewCities");
        }


    }
}