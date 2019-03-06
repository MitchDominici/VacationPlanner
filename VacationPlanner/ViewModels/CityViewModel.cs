using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacationPlanner.ViewModels
{
    public class CityViewModel
    {
        public int ID { get; set; }
        [StringLength( 450 )]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display( Name = "End Date" )]
        public DateTime EndDate { get; set; }
    }
}
