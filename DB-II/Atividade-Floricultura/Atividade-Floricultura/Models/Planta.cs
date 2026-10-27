using System.ComponentModel.DataAnnotations;

namespace Atividade_Floricultura.Models
{
    public class Planta
    {
        [Key]
        public Guid Id { get; set; }

        public TipoPlanta Tipo { get; set; }

        public string? Nome { get; set; }

        public float ValorSensor { get; set; }

        public Evento EventoSensor { get; set; }
    }

    public enum TipoPlanta
    {
        Florífera,
        Arbustiva,
        Trepadeira,
        Hortaliça,
        Leguminosa,
        Tubérculo,
        Erva,
        Arbusto,
        Submersa
    }

    public enum Evento
    {
        Estabilizada = 0,
        PrecisaÁgua = 1,
        MuitoSeca = 2,
        MuitoÚmida = 3
    }
}
