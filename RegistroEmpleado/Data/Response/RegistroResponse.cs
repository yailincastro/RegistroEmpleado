using RegistroEmpleado.Data.Request;

namespace RegistroEmpleado.Data.Response
{
    public class RegistroResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string FechaInicio { get; set; } = null!;
        public string SueldoInicial { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;

        public RegistroRequest ToRequest()
        {
            return new RegistroRequest
            {
                Id = Id,
                Nombre = Nombre,
                Apellido = Apellido,
                Cedula = Cedula,
                Codigo = Codigo,
                FechaInicio = FechaInicio,
                SueldoInicial = SueldoInicial,
                Ocupacion = Ocupacion
            };

        }
    }
}
