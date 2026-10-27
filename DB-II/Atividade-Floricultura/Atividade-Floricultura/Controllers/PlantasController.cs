using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Atividade_Floricultura;
using Atividade_Floricultura.Models;

namespace Atividade_Floricultura.Controllers
{
    public class PlantasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlantasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Plantas.ToListAsync());
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planta = await _context.Plantas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
        }

        public IActionResult Create()
        {
            var tiposPlanta = Enum.GetValues(typeof(TipoPlanta))
                                   .Cast<TipoPlanta>()
                                   .Select(e => new SelectListItem
                                   {
                                       Value = ((int)e).ToString(),
                                       Text = e.ToString()
                                   });

            ViewBag.TipoPlantaList = new SelectList(tiposPlanta, "Value", "Text");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Nome,ValorSensor")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                planta.Id = Guid.NewGuid();
                planta.EventoSensor = DeterminarEvento(planta.ValorSensor);

                _context.Add(planta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planta);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planta = await _context.Plantas.FindAsync(id);
            if (planta == null)
            {
                return NotFound();
            }

            PopularSelectLists();
            return View(planta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Tipo,Nome,ValorSensor")] Planta planta)
        {
            if (id != planta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    planta.EventoSensor = DeterminarEvento(planta.ValorSensor);

                    _context.Update(planta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantaExists(planta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            PopularSelectLists();
            return View(planta);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planta = await _context.Plantas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planta == null)
            {
                return NotFound();
            }

            return View(planta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var planta = await _context.Plantas.FindAsync(id);
            if (planta != null)
            {
                _context.Plantas.Remove(planta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantaExists(Guid id)
        {
            return _context.Plantas.Any(e => e.Id == id);
        }

        private void PopularSelectLists()
        {
            var tiposPlanta = Enum.GetValues(typeof(TipoPlanta))
                .Cast<TipoPlanta>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString()
                });

            ViewBag.TipoPlantaList = new SelectList(tiposPlanta, "Value", "Text");

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
