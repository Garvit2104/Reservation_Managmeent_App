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

        public ReservationResponseDTO AddReservation(ReservationRequestDTO addReservation)
        {
            var addedReservation = _reservationService.AddReservation(addReservation);
            return addedReservation;
        }
    }
}
