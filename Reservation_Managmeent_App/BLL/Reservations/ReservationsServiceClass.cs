using Reservation_Managmeent_App.DAL.Reservations;
using Reservation_Managmeent_App.DTOs.Reservations;
using Reservation_Managmeent_App.DTOs.ReservationsDTO;
using Reservation_Managmeent_App.Models;
namespace Reservation_Managmeent_App.BLL.Reservations
{
    public class ReservationsServiceClass: IReservationService
    {
        private readonly IReservationRepos _reservationRepos;

        public ReservationsServiceClass(IReservationRepos _reservationRepos)
        {
            this._reservationRepos = _reservationRepos;
        }

        public ReservationResponseDTO AddReservation(ReservationRequestDTO addReservationRecord)
        {
            var reservationEntity = new Reservation
            {
                ReservationDoneByEmployeeId = addReservationRecord.ReservationDoneByEmployeeId,
                TravelRequestId = addReservationRecord.TravelRequestId,
                ReservationTypeId = addReservationRecord.ReservationTypeId,
                CreatedOn = addReservationRecord.CreatedOn,
                ReservationDoneWithEntity = addReservationRecord.ReservationDoneWithEntity,
                ReservationDate = addReservationRecord.ReservationDate,
                Amount = addReservationRecord.Amount,
                ConfirmationId = addReservationRecord.ConfirmationId,
                Remarks = addReservationRecord.Remarks

            };
            var addedReservation = _reservationRepos.AddReservations(reservationEntity);

            ReservationResponseDTO reservationResponse = new ReservationResponseDTO
            {
                Id = addedReservation.Id,
                ReservationDoneByEmployeeId = addedReservation.ReservationDoneByEmployeeId,
                TravelRequestId = addedReservation.TravelRequestId,
                ReservationTypeId = addedReservation.ReservationTypeId,
                CreatedOn = addedReservation.CreatedOn,
                ReservationDoneWithEntity = addedReservation.ReservationDoneWithEntity,
                ReservationDate = addedReservation.ReservationDate,
                Amount = addedReservation.Amount,
                ConfirmationId = addedReservation.ConfirmationId,
                Remarks = addedReservation.Remarks
            };
            return reservationResponse;
        }
    }
}
