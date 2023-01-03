using System;
using System.Collections.Generic;

namespace FactoryEquipmentsAPI.Models;

public partial class Equipment : BaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    public virtual ICollection<StatusLog> StatusLogs { get; } = new List<StatusLog>();
}
