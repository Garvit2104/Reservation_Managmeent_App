using Reservation_Managmeent_App.Models;

namespace Reservation_Managmeent_App.DAL.Reservations
{
    public interface IReservationRepos
    {
        public Reservation AddReservations(Reservation reservation);
    }
}
