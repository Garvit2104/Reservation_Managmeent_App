using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation_Managmeent_App.BLL.ReservationTypes;
using Reservation_Managmeent_App.DTOs.ReservationTypes_DTO;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationTypeController : ControllerBase
    {
        private readonly IReservationTypeService _reservationTypeService;

        public ReservationTypeController(IReservationTypeService _reservationTypeService)
        {
            this._reservationTypeService = _reservationTypeService;
        }

        [HttpGet("types")]

        public async Task<IActionResult> GetReservationType()
        {
            var result = await _reservationTypeService.GetReservationTypes();
            return Ok(result);
        }
    }
}
