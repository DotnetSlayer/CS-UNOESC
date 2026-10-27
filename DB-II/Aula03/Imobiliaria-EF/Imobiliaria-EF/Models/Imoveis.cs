using System.ComponentModel.DataAnnotations;

namespace Imobiliaria_EF.Models
{
    public class Imoveis
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int NumeroQuartos { get; set; }
        public float Valor {  get; set; }

    }
}
