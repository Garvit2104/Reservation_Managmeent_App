using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Reservation_Managmeent_App.BLL.ReservationDocs;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDocsController : ControllerBase
    {
        private readonly IReservationDocsService _reservationDocsServices;

        public ReservationDocsController(IReservationDocsService _reservationDocsServices)
        {
            this._reservationDocsServices = _reservationDocsServices;
        }

        [HttpPost("upload-reservation-doc/{reservationId}")]

        public async Task<IActionResult> UploadReservationDoc(int reservationId, [FromForm] IFormFile file)
        {
            await _reservationDocsServices.UploadReservationDocs(reservationId, file);
            return Ok(new { Message = "Document Uploaded successfully" });
        }

        [HttpGet("reservations/{reservationId}/download")]

        public async Task<IActionResult> DownloadReservationDoc(int reservationId)
        {
            var fileResult = await _reservationDocsServices.GetReservationDoc(reservationId);

            if(fileResult == null)
            {
                return NotFound("Document Not found");
            }
            return File(fileResult.FileBytes, "application/pdf", fileResult.FileName);

        }
    }
}
