using Reservation_Managmeent_App.DTOs.ReservationTypes_DTO;
using Reservation_Managmeent_App.DAL.ReservationTypes;

namespace Reservation_Managmeent_App.BLL.ReservationTypes
{
    public class ReservationTypesService : IReservationTypeService
    {
        private readonly IReservationTypeRepos _reservationTypeRepos;

        public ReservationTypesService(IReservationTypeRepos _reservationTypeRepos)
        {
            this._reservationTypeRepos = _reservationTypeRepos;
        }
        public List<ReservationTypeResponseDTO> GetReservationType()
        {
            var resTypes = _reservationTypeRepos.GetReservationTypes();

            List<ReservationTypeResponseDTO> ls = new List<ReservationTypeResponseDTO>();

            foreach (var item in resTypes)
            {
                ReservationTypeResponseDTO reservationTypeResponse = new ReservationTypeResponseDTO();
                reservationTypeResponse.TypeId = item.TypeId;
                reservationTypeResponse.TypeName = item.TypeName;

                ls.Add(reservationTypeResponse);
            }
            return ls;
        }

        public List<ReservationTypeResponseDTO> GetReservationTypeName()
        {
            List<ReservationTypeResponseDTO> reservationTypes = GetReservationType();

            foreach(var item in reservationTypes)
            {
                ReservationTypeResponseDTO reservationTypeName = new ReservationTypeResponseDTO();
                reservationTypeName.TypeName = item.TypeName;
                reservationTypes.Add(reservationTypeName);
            }
            return reservationTypes;
        }
    }
}
