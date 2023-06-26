using Microsoft.EntityFrameworkCore;
using RegistroEmpleado.Data.Models;

namespace RegistroEmpleado.Data.Context
{
    public interface IRegistroEmpleadoDbContext
    {
       public DbSet<Registro> Registros { get; set; }

       public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}