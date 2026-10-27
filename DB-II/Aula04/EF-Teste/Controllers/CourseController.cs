using EF_Teste.Models;
using EF_Teste.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EF_Teste.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _courseRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course Course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.Create(Course);
                return RedirectToAction("Index");
            }
            return View(Course);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var Course = await _courseRepository.GetById(id);
            if (Course == null)
            {
                return NotFound();
            }

            await _courseRepository.Delete(Course);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue) // Corrigido: agora só dá erro se o ID estiver ausente
                return BadRequest();

            var Course = await _courseRepository.GetById(id.Value);

            if (Course == null)
                return NotFound();

            return View(Course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Course Course)
        {
            if (!id.HasValue) // Corrigido
                return BadRequest();

            if (id.Value != Course.ID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _courseRepository.Update(Course);
                return RedirectToAction("Index");
            }

            return View(Course);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var Course = await _courseRepository.GetById(id);
            if (Course == null)
            {
                return NotFound();
            }
            return View(Course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course Course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.Update(Course);
                return RedirectToAction("Index");
            }
            return View(Course);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}