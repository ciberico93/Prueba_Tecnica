using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI_PruebaTecnica.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string? Descripcion { get; set; }
    [JsonIgnore]
    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
