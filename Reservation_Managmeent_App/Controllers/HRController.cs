using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation_Managmeent_App.ClientMicroServices.Client_HR;
using Reservation_Managmeent_App.DTOs.ClientDTO;

namespace Reservation_Managmeent_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        private readonly IClient_HR_Service _client_HR_Service;

        public HRController(IClient_HR_Service _client_HR_Service)
        {
            this._client_HR_Service = _client_HR_Service;
        }

        [HttpGet("employees/{id}")]

        public async Task<EmployeeResponseDTO> GetEmployeeById(int id)
        {
            var employee = await _client_HR_Service.GetEmployeeById(id);
            return employee;
        }
    }
}
