
using HomeTask.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeTask.Data

{
    public class AppDbContext : DbContext
    {

        public DbSet<Operator> Operators { get; set; }
       


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



    }
}
