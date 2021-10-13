using chatty.Models;
using Microsoft.EntityFrameworkCore;

namespace chatty.Data
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {
        }
        public DbSet<AirportEvent> AirportEvents { get; set; }
        public DbSet<DutyRoster> DutyRoasters { get; set; }
    }
}
