using Microsoft.EntityFrameworkCore;
using mototrack_backend_dotnet.Domain.Entities;

namespace mototrack_backend_dotnet.Infrastructure.AppData;

public class ApplicationContext  : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<OrdemServicoEntity> OrdemServico { get; set; }
}
