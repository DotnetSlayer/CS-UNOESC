using Atividade_Floricultura.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade_Floricultura
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Atividade_Floricultura.Models.Planta> Plantas { get; set; } = default!;

    }
}
