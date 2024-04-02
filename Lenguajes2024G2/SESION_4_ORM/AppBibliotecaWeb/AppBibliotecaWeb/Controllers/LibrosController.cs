using Microsoft.AspNetCore.Mvc;
using AppBibliotecaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaWeb.Controllers
{
    public class LibrosController : Controller
    {
        //variable para mamejar e ORM Entity Framework Core
        private readonly DbContextBiblioteca _context;

        //Constructor con parámetros
        public LibrosController(DbContextBiblioteca context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var listado = await _context.Libros.ToListAsync();

            return View(listado);
        }
        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
