using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagemenetApp.EntityFramework
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }

        public DbSet<Registration> Registration { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<States> States { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<Dishtypes> Dishtypes { get; set; }
        public DbSet<Light> Light { get; set; }
        public DbSet<Flower> Flower { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<BookingVenue> BookingVenue { get; set; }


    }
}
