using System;
using System.Collections.Generic;

namespace Reservation_Managmeent_App.Models;

public partial class ReservationType
{
    public int TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
