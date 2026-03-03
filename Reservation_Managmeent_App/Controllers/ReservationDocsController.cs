using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation_Managmeent_App.BLL.ReservationDocs;
using Reservation_Managmeent_App.DTOs.DownloadDTOs;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationDocsController : ControllerBase
    {
        private readonly IReservationDocsService _reservationDocsServices;

        public ReservationDocsController(IReservationDocsService _reservationDocsServices)
        {
            this._reservationDocsServices = _reservationDocsServices;
        }

        
        // GET /api/reservations/{reservationId}/download
        [HttpGet("{reservationId}/download")]
        public async Task<IActionResult> DownloadReservationDoc(int reservationId)
        {
            var fileResult = await _reservationDocsServices.GetReservationDoc(reservationId);
            if (fileResult == null)
            {
                return NotFound("Document Not found");
            }
            return File(fileResult.FileBytes, "application/pdf", fileResult.FileName);
        }
    }
}