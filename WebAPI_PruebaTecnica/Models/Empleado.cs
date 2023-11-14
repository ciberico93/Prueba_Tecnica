using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPI_PruebaTecnica.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public int? IdCargo { get; set; }
    [JsonIgnore]

    public virtual Cargo? IdCargoNavigation { get; set; }

    
}
