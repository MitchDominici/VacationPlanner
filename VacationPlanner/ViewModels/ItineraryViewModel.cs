using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using VacationPlanner.Models;

namespace VacationPlanner.ViewModels
{
    public class ItineraryViewModel
    {
      
        public int ID { get; set; }
        [StringLength( 450 )]
        public string Location { get; set; }
        public int CityDatesId { get; set; }

        public List<City> Cities { get; set; }

        
        
    }


}
