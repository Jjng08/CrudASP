using Microsoft.AspNetCore.Mvc;
using CrudASP.Data;
using CrudASP.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudASP.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly AppDataContext _context;

        public EmpleadoController(AppDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Empleado> lista = await _context.Empleados.ToListAsync();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                await _context.Empleados.AddAsync(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Empleado empleado = await _context.Empleados.FirstAsync(e => e.IdEmpleado == id);
            return View(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Empleados.Update(empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Empleado empleado = await _context.Empleados.FirstAsync(e => e.IdEmpleado == id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
