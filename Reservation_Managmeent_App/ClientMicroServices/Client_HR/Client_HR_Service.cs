using Reservation_Managmeent_App.DTOs.ClientDTO;
namespace Reservation_Managmeent_App.ClientMicroServices.Client_HR
{
    public class Client_HR_Service: IClient_HR_Service
    {
        private readonly HttpClient _httpClinet;

        public Client_HR_Service(HttpClient _httpClinet)
        {
            this._httpClinet = _httpClinet;
        }

        public async Task<EmployeeResponseDTO> GetEmployeeById(int id)
        {
            var empResponse = await _httpClinet.GetAsync($"/api/Employees/{id}");

            var user = await empResponse.Content.ReadFromJsonAsync<EmployeeResponseDTO>();      
            return user;
        }
    }
}
