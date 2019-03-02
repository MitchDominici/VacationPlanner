using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacationPlanner.Models
{
    public class City
    {
        public City() { }

        public int ID { get; set; }
        [StringLength( 450 )]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IList<Event> Events { get; set; }
        
    }
}
