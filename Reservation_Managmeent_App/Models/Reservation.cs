using System;
using System.Collections.Generic;

namespace Reservation_Managmeent_App.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public int? ReservationDoneByEmployeeId { get; set; }

    public int? TravelRequestId { get; set; }

    public int? ReservationTypeId { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public string? ReservationDoneWithEntity { get; set; }

    public DateOnly? ReservationDate { get; set; }

    public int? Amount { get; set; }

    public string? ConfirmationId { get; set; }

    public string Remarks { get; set; } = null!;

    public virtual ICollection<ReservationDoc> ReservationDocs { get; set; } = new List<ReservationDoc>();

    public virtual ReservationType? ReservationType { get; set; }
}
