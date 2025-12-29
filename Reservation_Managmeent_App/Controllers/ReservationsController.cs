using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Reservation_Managmeent_App.DTOs.Reservations;
using Reservation_Managmeent_App.DTOs.ReservationsDTO;
using Reservation_Managmeent_App.BLL.Reservations;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationsController(IReservationService _reservationService)
        {
            this._reservationService = _reservationService;
        }
        [HttpPost("reservations/add")]

        public async Task<ReservationResponseDTO> AddReservation(ReservationRequestDTO addReservation)
        {
            var addedReservation = await _reservationService.AddReservation(addReservation);
            return addedReservation;
        }

        [HttpGet("reservations/track/{travelRequestid}")]

        public ReservationResponseDTO TrackReservationsByTrid(int travelRequestid)
        {
            var response = _reservationService.GetTrackReservationByTrid(travelRequestid);
            return response;
        }

        [HttpGet("reservations/{reservationid}")]

        public ReservationResponseDTO GetReservationDetails(int reservationid)
        {
            var response = _reservationService.GetReservationDetails(reservationid);
            return response;
        }
    }
}
