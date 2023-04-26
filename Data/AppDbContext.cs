using Microsoft.EntityFrameworkCore;
using MultipleConnection.Models;

namespace MultipleConnection.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
    }
}
