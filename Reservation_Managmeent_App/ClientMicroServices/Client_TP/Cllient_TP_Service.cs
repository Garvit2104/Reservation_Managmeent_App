using Azure;
using Reservation_Managmeent_App.DTOs.ClientDTO;
namespace Reservation_Managmeent_App.ClientMicroServices.Client_TP
{
    public class Client_TP_Service: IClient_TP_Service
    {
        private readonly HttpClient _tphttpClient;
        public Client_TP_Service(IHttpClientFactory httpClientFactory)
        {
            this._tphttpClient = httpClientFactory.CreateClient("TravelPlanner");
        }
        public async Task<TravelResponseDTO> GetTravelRequestById(int trid)
        {
            var response = await _tphttpClient.GetAsync($"/api/TravelRequests/travelrequests/{trid}");
            if (!response.IsSuccessStatusCode)
                return null;

            var travelRequest =
                await response.Content.ReadFromJsonAsync<TravelResponseDTO>();

            return travelRequest;
        }

        public async Task<int> CalculateBudget(int travelRequestId)
        {
            var response = await _tphttpClient.GetAsync($"/api/GradesClientAPI/calculatebudget/{travelRequestId}");
            response.EnsureSuccessStatusCode(); // throws if not 2xx

            var content = await response.Content.ReadAsStringAsync();
            if (int.TryParse(content, out var budget))
                return budget;

            throw new FormatException($"Budget API returned non-integer content: {content}");
        }

    }
}
