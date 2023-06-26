using RegistroEmpleado.Data.Models;

namespace RegistroEmpleado.Data.Request
{
    public class RegistroRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string FechaInicio { get; set; } = null!;
        public string SueldoInicial { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;

    }
}
