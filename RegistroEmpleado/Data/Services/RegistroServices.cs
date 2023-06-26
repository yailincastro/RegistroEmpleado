using Microsoft.EntityFrameworkCore;
using RegistroEmpleado.Data.Context;
using RegistroEmpleado.Data.Models;
using RegistroEmpleado.Data.Request;
using RegistroEmpleado.Data.Response;

namespace RegistroEmpleado.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class Result<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public class RegistroServices : IRegistroServices
    {
        private readonly IRegistroEmpleadoDbContext dbContext;
        public RegistroServices(IRegistroEmpleadoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(RegistroRequest request)
        {
            try
            {
                var registro = Registro.Crear(request);
                dbContext.Registros.Add(registro);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(RegistroRequest request)
        {
            try
            {
                var registro = await dbContext.Registros.FirstOrDefaultAsync(R => R.Id == request.Id);
                if (registro == null)
                    return new Result() { Message = "No se encontro registro de empleado", Success = false };

                if (registro.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(RegistroRequest request)
        {
            try
            {
                var registro = await dbContext.Registros.FirstOrDefaultAsync(R => R.Id == request.Id);
                if (registro == null)
                    return new Result() { Message = "No se encontro registro de empleado", Success = false };
                dbContext.Registros.Remove(registro);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<RegistroResponse>>> Consultar(string filtro)
        {
            try
            {
                var registro = await dbContext.Registros.Where(R => (R.Nombre + " " + R.Apellido + " " + R.Cedula + " " + R.Codigo + " " + R.FechaInicio + " " + R.SueldoInicial + " " + R.Ocupacion)
                .ToLower()
                .Contains(filtro.ToLower()
                )
              )
                    .Select(R => R.ToResponse())
                    .ToListAsync();
                return new Result<List<RegistroResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = registro
                };

            }
            catch (Exception E)
            {
                return new Result<List<RegistroResponse>>()
                {
                    Message = E.Message,
                    Success = false
                };

            }
        }
    }
}
