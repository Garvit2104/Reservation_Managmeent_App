using Reservation_Managmeent_App.DTOs.ClientDTO;

namespace Reservation_Managmeent_App.ClientMicroServices.Client_HR
{
    public interface IClient_HR_Service
    {
        public Task<EmployeeResponseDTO> GetEmployeeById(int id);
    }
}
