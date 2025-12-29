using Reservation_Managmeent_App.Models;

namespace Reservation_Managmeent_App.DAL.Reservations
{
    public interface IReservationRepos
    {
        public Reservation AddReservations(Reservation reservation);

        public Reservation GetReservationByTravelRequestId(int travelRequestId);

        public int CountReservationsByTravelRequestId(int travelRequestId);


        public bool ExistsReservationOfAnyType(int travelRequestId, params int[] typeIds);

        public Reservation GetReservationDetails(int reservationId);
    }
}
