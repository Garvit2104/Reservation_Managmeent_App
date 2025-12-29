using Reservation_Managmeent_App.DTOs.ClientDTO;
namespace Reservation_Managmeent_App.ClientMicroServices.Client_HR
{
    public class Client_HR_Service: IClient_HR_Service
    {
        private readonly HttpClient _hrhttpClient;

        public Client_HR_Service(IHttpClientFactory httpClientFactory)
        {
            this._hrhttpClient = httpClientFactory.CreateClient("HumanResource");
        }

        public async Task<EmployeeResponseDTO> GetEmployeeById(int id)
        {
            var empResponse = await _hrhttpClient.GetAsync($"/api/Users/employee/{id}");

            if (!empResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed: {empResponse.StatusCode}");
            }

            var user = await empResponse.Content.ReadFromJsonAsync<EmployeeResponseDTO>();      
            return user;
        }
    }
}
