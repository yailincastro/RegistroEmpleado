using RegistroEmpleado.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroEmpleado.Data.Context
{
    public class RegistroEmpleadoDbContext : DbContext, IRegistroEmpleadoDbContext
    {
        private readonly IConfiguration config;

        public RegistroEmpleadoDbContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Registro> Registros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
