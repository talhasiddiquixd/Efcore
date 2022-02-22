using Microsoft.EntityFrameworkCore;
using SampleApi.Models;

namespace Hospital_Managment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      public DbSet<NationalPark> NationalPark { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Trail> Trail { get; set; }
    }

    //public DbSet<Appointment> Appointment { get; set; }




}
