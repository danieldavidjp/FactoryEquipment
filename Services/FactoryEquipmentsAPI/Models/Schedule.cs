using System;
using System.Collections.Generic;

namespace FactoryEquipmentsAPI.Models;

public partial class Schedule : BaseEntity
{
    public Guid Id { get; set; }

    public Guid? EquipmentId { get; set; }

    public string? State { get; set; }

    public string? Status { get; set; }

    public virtual Equipment? Equipment { get; set; }
}
