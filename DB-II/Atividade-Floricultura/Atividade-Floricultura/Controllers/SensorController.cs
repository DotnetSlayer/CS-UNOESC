using Atividade_Floricultura.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade_Floricultura.Controllers
{
    public class SensorController : Controller
    {
        [HttpPost]
        public IActionResult RegistrarSensor([FromBody] SensorModel model)
        {
            model.Evento = DeterminarEvento(model.ValorSensor);

            return Ok(model);
        }

        private Evento DeterminarEvento(float valorsensor)
        {
            if (valorsensor >= 0 && valorsensor < 20)
                return Evento.MuitoSeca;
            else if (valorsensor >= 20 && valorsensor < 50)
                return Evento.PrecisaÁgua;
            else if (valorsensor >= 50 && valorsensor < 80)
                return Evento.Estabilizada;
            else
                return Evento.MuitoÚmida;
        }
    }
}
