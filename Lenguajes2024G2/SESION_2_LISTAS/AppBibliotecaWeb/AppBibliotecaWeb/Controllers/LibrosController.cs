using Microsoft.AspNetCore.Mvc;


//implementacion de model
using AppBibliotecaWeb.Models;


namespace AppBibliotecaWeb.Controllers
{
    public class LibrosController : Controller
    {
        //lista para manejar libros
        private static List<Libro> listado = null;

        public LibrosController()
        {
            if (listado == null)
            {
                //Se crea la instancia
                listado = new List<Libro>();

                //Se agregan libros al listado
                listado.Add(new Libro()
                {
                    ISBN = 48,
                    Titulo = "Lenguajes Progromacion",
                    Editorial = "Imprenta La Violeta",
                    PrecioVenta = 75000,
                    FechaPublicacion = DateTime.Now,
                    Estado = 'A',
                    Foto = "ND"
                });

                //Se agregan libros al listado
                listado.Add(new Libro()
                {
                    ISBN = 77,
                    Titulo = "Programacion II",
                    Editorial = "Imprenta San José",
                    PrecioVenta = 45250,
                    FechaPublicacion = DateTime.Now,
                    Estado = 'A',
                    Foto = "ND"
                });
            }
        }
        public IActionResult Index()
        {
            //se envia la lista de objetos aal frontend
            return View(listado);
        }
    }
}
