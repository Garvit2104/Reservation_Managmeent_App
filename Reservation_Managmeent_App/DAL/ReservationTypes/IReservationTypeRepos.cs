using Reservation_Managmeent_App.Models;

namespace Reservation_Managmeent_App.DAL.ReservationTypes
{
    public interface IReservationTypeRepos
    {
        public List<ReservationType> GetReservationTypes();
    }
}
