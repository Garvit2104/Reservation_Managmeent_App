using Reservation_Managmeent_App.DTOs.Reservations;
using Reservation_Managmeent_App.DTOs.ReservationsDTO;

namespace Reservation_Managmeent_App.BLL.Reservations
{
    public interface IReservationService
    {
        public ReservationResponseDTO AddReservation(ReservationRequestDTO createReservation);
    }
}
