using Microsoft.EntityFrameworkCore;

namespace ReserveApi.Models
{
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options) : base(options)
        {

        }


        public DbSet<Reservation> Reservations { get; set; }

    }
}
