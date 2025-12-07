using Reservation_Managmeent_App.Data;
using Reservation_Managmeent_App.Models;

namespace Reservation_Managmeent_App.DAL.ReservationTypes
{
    public class ReservationTypeRepos : IReservationTypeRepos
    {
        private readonly ReservationDbContext _context;

        public ReservationTypeRepos(ReservationDbContext _context)
        {
            this._context = _context;
        }

        public List<ReservationType> GetReservationTypes()
        {
            var data =  _context.ReservationTypes.ToList();
            return data;
        }
    }
}
