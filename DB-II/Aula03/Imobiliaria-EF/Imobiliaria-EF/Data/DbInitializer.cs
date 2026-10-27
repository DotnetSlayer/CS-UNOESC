using Imobiliaria_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Imobiliaria_EF.Data
{
    public static class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ImobiliariaContext(
                serviceProvider.GetRequiredService<DbContextOptions<ImobiliariaContext>>());

            context.Database.EnsureCreated();

            if (context.Imoveis.Any())
            {
                return; 
            }

            var imoveis = new Imoveis[]
            {
                new Imoveis { Nome = "Casa na Praia", Descricao = "Casa com vista para o mar", NumeroQuartos = 3, Valor = 500000 },
                new Imoveis { Nome = "Apartamento Central", Descricao = "Apartamento no centro da cidade", NumeroQuartos = 2, Valor = 350000 },
                new Imoveis { Nome = "Sítio", Descricao = "Sítio com área verde", NumeroQuartos = 4, Valor = 750000 },
            };

            foreach(Imoveis imovel in imoveis)
            {
                context.Imoveis.Add(imovel);
            }

            context.Imoveis.AddRange(imoveis);
            context.SaveChanges();

            var inquilinos = new Inquilino[]
            {
                new Inquilino { Nome = "João da Silva", Idade = "30", QuantImoveis = 1 },
                new Inquilino { Nome = "Maria Oliveira", Idade = "45", QuantImoveis = 2 },
            };

            foreach (Inquilino inquilino in inquilinos)
            {
                context.Inquilinos.Add(inquilino);
            }

            context.Inquilinos.AddRange(inquilinos);
            context.SaveChanges();

            var inquilinoImoveis = new InquilinoImoveis[]
            {
                new InquilinoImoveis { InquilinoId = inquilinos[0].Id, ImovelId = imoveis[0].Id },
                new InquilinoImoveis { InquilinoId = inquilinos[1].Id, ImovelId = imoveis[1].Id },
                new InquilinoImoveis { InquilinoId = inquilinos[1].Id, ImovelId = imoveis[2].Id },
            };

            foreach (InquilinoImoveis inquilinoImovel in inquilinoImoveis)
            {
                context.InquilinoImoveis.Add(inquilinoImovel);
            }

            context.InquilinoImoveis.AddRange(inquilinoImoveis);
            context.SaveChanges();
        }

        internal static void Initialize(ImobiliariaContext context)
        {
            throw new NotImplementedException();
        }
    }
}
