using Imobiliaria_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria_EF.Data
{
    public class ImobiliariaContext : DbContext
    {
        public ImobiliariaContext(DbContextOptions<ImobiliariaContext> options) : base(options)
        {
        }

        public DbSet<Imoveis> Imoveis { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<InquilinoImoveis> InquilinoImoveis { get; set; }

    }
}
