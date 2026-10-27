using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imobiliaria_EF.Models
{
    [PrimaryKey(nameof(InquilinoId), nameof(ImovelId))]
    public class InquilinoImoveis
    {
        public int InquilinoId { get; set; }

        //Property Navigations
        [ForeignKey(nameof(InquilinoId))]
        public Inquilino? Inquilino { get; set; }

        public int ImovelId { get; set; }

        //Property Navigations
        [ForeignKey(nameof(ImovelId))]
        public Imoveis? Imovel { get; set; }
    }
}
