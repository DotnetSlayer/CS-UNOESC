using System.ComponentModel.DataAnnotations;

namespace Imobiliaria_EF.Models
{
    public class Inquilino
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Idade { get; set; }
        public int QuantImoveis { get; set; }
    }
}
