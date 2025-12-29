using Reservation_Managmeent_App.DTOs.ClientDTO;

namespace Reservation_Managmeent_App.ClientMicroServices.Client_TP
{
    public interface IClient_TP_Service
    {
        public Task<TravelResponseDTO> GetTravelRequestById(int id);

        public Task<int> CalculateBudget(int travelRequestId);
    }
}
