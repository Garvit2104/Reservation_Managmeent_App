using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation_Managmeent_App.ClientMicroServices.Client_TP;
using Reservation_Managmeent_App.DTOs.ClientDTO;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPlannerController : ControllerBase
    {
        private readonly IClient_TP_Service _clinet_TP_Service;

        public TravelPlannerController(IClient_TP_Service _clinet_TP_Service)
        {
            this._clinet_TP_Service = _clinet_TP_Service;
        }

        [HttpGet("travelrequests{trid}")]
        public async Task<TravelResponseDTO> GetTravelRequestById(int id)
        {
            var result = await _clinet_TP_Service.GetTravelRequestById(id);
            return result;
        }
    }
}