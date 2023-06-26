using RegistroEmpleado.Data.Request;
using RegistroEmpleado.Data.Response;

namespace RegistroEmpleado.Data.Services
{
    public interface IRegistroServices
    {
        Task<Result<List<RegistroResponse>>> Consultar(string filtro);
        Task<Result> Crear(RegistroRequest request);
        Task<Result> Eliminar(RegistroRequest request);
        Task<Result> Modificar(RegistroRequest request);
    }
}