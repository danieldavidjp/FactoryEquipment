using System;
using System.Collections.Generic;

namespace FactoryEquipmentsAPI.Models;

public partial class StatusLog : BaseEntity
{
    public Guid Id { get; set; }

    public string? Status { get; set; }

    public Guid? EquipmentId { get; set; }

    public virtual Equipment? Equipment { get; set; }
}
