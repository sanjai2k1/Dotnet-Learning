using Microsoft.AspNetCore.Mvc;

namespace ReservationApiCRUD.Models
{
    public interface IRepository
    {
        Task<Reservation> AddReservationAsync(Reservation reservation);
        Task<Reservation> GetReservationByIdAsync(int id);

        Task<IEnumerable<Reservation>> GetAll();

        Task<Reservation> UpdateReservation(Reservation updatedReservation);

        Task<bool>  DeleteReservation(int id);

    }
}
