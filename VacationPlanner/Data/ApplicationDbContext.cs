using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VacationPlanner.Models;

namespace VacationPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<City> City { get; set; }
        


        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options )
            : base( options )
        {
        }

      
    }
}
