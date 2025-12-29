using Microsoft.EntityFrameworkCore;
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

        public Reservation GetReservationByTravelRequestId(int travelRequestId)
        {
            return  _context.Reservations.AsNoTracking().FirstOrDefault(r=>r.TravelRequestId == travelRequestId);
            
        }


        public int CountReservationsByTravelRequestId(int travelRequestId)
        {
            return _context.Reservations.AsNoTracking().Count(r => r.TravelRequestId == travelRequestId);
        }

        public bool ExistsReservationOfAnyType(int travelRequestId, params int[] typeIds)
        {
            return _context.Reservations
                           .AsNoTracking()
                           .Any(r => r.TravelRequestId == travelRequestId
                                  && r.ReservationTypeId.HasValue
                                  && typeIds.Contains(r.ReservationTypeId.Value));
        }

        public Reservation GetReservationDetails(int reservationId)
        {
            return _context.Reservations.AsNoTracking().FirstOrDefault(rid => rid.ReservationDoneByEmployeeId == reservationId);
        }

    }
}
