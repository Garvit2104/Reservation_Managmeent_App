using Reservation_Managmeent_App.Data;
using Reservation_Managmeent_App.Models;
namespace Reservation_Managmeent_App.DAL.Reservations
{
    public class ReservationRepos: IReservationRepos
    {
        private readonly ReservationDbContext _context;

        public ReservationRepos(ReservationDbContext _context)
        {
            this._context = _context;
        }

        public Reservation AddReservations(Reservation reservation)
        {
            var addedReservation = _context.Reservations.Add(reservation).Entity;
            _context.SaveChanges();
            return addedReservation;
        }
    }
}
