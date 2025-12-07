using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation_Managmeent_App.BLL.ReservationTypes;
using Reservation_Managmeent_App.DTOs.ReservationTypes_DTO;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationTypeController : ControllerBase
    {
        private readonly IReservationTypeService _reservationTypeService;

        public ReservationTypeController(IReservationTypeService _reservationTypeService)
        {
            this._reservationTypeService = _reservationTypeService;
        }

        [HttpGet("reservations/types")]

        public List<ReservationTypeResponseDTO> GetReservationType()
        {
            var result = _reservationTypeService.GetReservationType();
            return result;
        }
    }
}
