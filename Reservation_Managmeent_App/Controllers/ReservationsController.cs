using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Reservation_Managmeent_App.DTOs.Reservations;
using Reservation_Managmeent_App.DTOs.ReservationsDTO;
using Reservation_Managmeent_App.BLL.Reservations;
using Reservation_Managmeent_App.BLL.ReservationDocs;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationDocsService _reservationDocsService;
        public ReservationsController(IReservationService _reservationService, IReservationDocsService _reservationDocsService)
        {
            this._reservationService = _reservationService;
            this._reservationDocsService = _reservationDocsService;
        }
        [HttpPost("add")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddReservation([FromForm] ReservationRequestDTO addReservation)
        {
            var addedReservation = await _reservationService.AddReservation(addReservation);
            if (addReservation.File != null)
            {
                // Use the newly created reservation's Id
                // to link the document to the reservation
                await _reservationDocsService
                    .UploadReservationDocs(
                        addedReservation.Id,      // ← Id from Step 1
                        addReservation.File);     // ← PDF file
            }
            return Ok(addedReservation);
        }

        [HttpGet("track/{travelRequestid}")]

        public async Task<IActionResult> TrackReservationsByTravelRequestId(int travelRequestid)
        {
            var response = await _reservationService.GetReservationByTravelRequestId(travelRequestid);

            if (response == null || response.Count == 0)
                return NotFound(new
                {
                    message =
                    $"No reservations found for TravelRequestId: {travelRequestid}"
                });

            return Ok(response);
        }

        [HttpGet("reservationid")]

        public async Task<IActionResult> GetReservationDetails(int reservationid)
        {
            var response = await _reservationService.GetReservationDetails(reservationid);

            if (response == null)
                return NotFound(new
                {
                    message =
                    $"Reservation {reservationid} not found"
                });
            return Ok(response);
        }
    }
}
