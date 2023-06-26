using RegistroEmpleado.Data.Request;
using RegistroEmpleado.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RegistroEmpleado.Data.Models
{
    public class Registro
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string FechaInicio { get; set; } = null!;
        public string SueldoInicial { get; set; } = null!;
        public string Ocupacion { get; set; } = null!;

        public static Registro Crear(RegistroRequest registro) => new Registro()
        {
            Nombre = registro.Nombre,
            Apellido = registro.Apellido,
            Cedula = registro.Cedula,
            Codigo = registro.Codigo,
            FechaInicio = registro.FechaInicio,
            SueldoInicial = registro.SueldoInicial,
            Ocupacion = registro.Ocupacion,
        };
        public bool Modificar(RegistroRequest registro)
        {
            var cambio = false;
            if (Nombre != registro.Nombre)
            {
                Nombre = registro.Nombre;
                cambio = true;
            }
            if (Apellido != registro.Apellido)
            {
                Apellido = registro.Apellido;
                cambio = true;
            }
            if (Cedula != registro.Cedula)
            {
                Cedula = registro.Cedula;
                cambio = true;
            }
            if (Codigo != registro.Codigo)
            {
                Codigo = registro.Codigo;
                cambio = true;
            }
            if (FechaInicio != registro.FechaInicio)
            {
                FechaInicio = registro.FechaInicio;
                cambio = true;
            }
            if (SueldoInicial != registro.SueldoInicial)
            {
                SueldoInicial = registro.SueldoInicial;
                cambio = true;
            }
            if (Ocupacion != registro.Ocupacion)
            {
                Ocupacion = registro.Ocupacion;
                cambio = true;
            }
            return cambio;
        }
        public RegistroResponse ToResponse()
           => new RegistroResponse()
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
