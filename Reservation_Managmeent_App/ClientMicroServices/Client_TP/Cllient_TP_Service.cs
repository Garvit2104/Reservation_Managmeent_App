using Azure;
using Reservation_Managmeent_App.DTOs.ClientDTO;
namespace Reservation_Managmeent_App.ClientMicroServices.Client_TP
{
    public class Client_TP_Service: IClient_TP_Service
    {
        private readonly HttpClient _httpClinet;
        public Client_TP_Service(HttpClient _httpClinet)
        {
            this._httpClinet = _httpClinet;
        }
        public async Task<TravelResponseDTO> GetTravelRequestById(int id)
        {
            var response = await _httpClinet.GetAsync($"/api/TravelRequests/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            var travelRequest =
                await response.Content.ReadFromJsonAsync<TravelResponseDTO>();

            return travelRequest;
        }
    }
}
