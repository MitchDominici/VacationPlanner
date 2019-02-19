using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using VacationPlanner.Models;


namespace VacationPlanner.ViewModels
{
    public class SearchViewModel
    {
        public int ID { get; set; }
        [Required( ErrorMessage = "Search location is required" )]
        public string LocationName { get; set; }


    }

}
