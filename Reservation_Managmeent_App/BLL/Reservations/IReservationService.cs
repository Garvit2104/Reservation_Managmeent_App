using Reservation_Managmeent_App.DTOs.Reservations;
using Reservation_Managmeent_App.DTOs.ReservationsDTO;

namespace Reservation_Managmeent_App.BLL.Reservations
{
    public interface IReservationService
    {
        Task<ReservationResponseDTO> AddReservation(ReservationRequestDTO addReservationRecord);

        public List<ReservationResponseDTO> GetReservationByTravelRequestId(int trid);

        public ReservationResponseDTO GetTrackReservationByTrid(int trid);

        public ReservationResponseDTO GetReservationDetails(int reservationId);
    }
}
