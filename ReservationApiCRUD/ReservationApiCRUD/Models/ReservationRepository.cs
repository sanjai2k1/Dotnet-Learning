
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReservationApiCRUD.Models
{
    public class ReservationRepository : IRepository
    {
        private readonly ReservationContext _context;


        public ReservationRepository(ReservationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
           return await _context.Reservations.ToArrayAsync<Reservation>();
        }

        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
          
            await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync(); // Save changes asynchronously
            return reservation;
        }

        public async Task<Reservation> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id); // Use FindAsync for async lookup by ID
        }

        public async Task<Reservation> UpdateReservation( Reservation updatedReservation)
        {
            var reservation = await _context.Reservations.FindAsync(updatedReservation.Id);
            if (reservation == null)
            {
                return null; // Return null if the reservation doesn't exist
            }

            // Update the reservation properties
            reservation.Name = updatedReservation.Name;
            reservation.StartLocation = updatedReservation.StartLocation;
            reservation.EndLocation = updatedReservation.EndLocation;
            // Update other properties as needed

            await _context.SaveChangesAsync(); // Save changes asynchronously
            return reservation; // Return the updated reservation
        }

        public async Task<bool> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return false; // Return false if the reservation doesn't exist
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
