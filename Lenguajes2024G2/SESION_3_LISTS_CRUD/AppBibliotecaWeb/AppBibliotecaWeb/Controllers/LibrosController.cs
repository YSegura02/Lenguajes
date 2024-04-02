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

        /// <summary>
        /// Método encargado de mostrar el listado de libros
        /// </summary>
        /// <returns></returns>

        public IActionResult Index()
        {
            //se envia la lista de objetos aal frontend
            return View(listado);
        }

        /// <summary>
        /// Método encargado de mostrar el formulario para registrar un libro
        /// </summary>
        /// <returns></returns>

        [HttpGet]  //extraer
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //
        [ValidateAntiForgeryToken]//sirve para evitar el uso excesivo de la recarga en el sitio. evitar copias del sitio
        public IActionResult create([Bind] Libro libro) 
        {
            //se valida si el objeto está vacío
            if (libro == null)
            {
                //mostramos el formulario para crear un libro
                //enviamos el objeto
                return View(libro);
            }
            else
            {
                //el libro tiene datos lo agregamos a la lista
                listado.Add(libro);

                //se ubica al usuario dentro del listado de libros
                return RedirectToAction("Index");
            }

        }

        ///Proceso de editar los datos
        ///
        [HttpGet]
        public IActionResult Edit(int id)//parametro para identificar el libro a editar
        {
            //se busca a libro dentro de la lista
            var lib = listado.FirstOrDefault(r => r.ISBN == id);

            //se envia el libro al formulari para mostrar los datos
            return View(lib);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, [Bind] Libro libro)
        {
            if(libro == null) //se valida si el libro no hay datos
            {
                return View(libro); //mostramos el formulario
            }
            else
            {
                if (id != libro.ISBN) //si el ISBN es diferente al libro
                {
                    return View(libro); //se carga el formulario
                }
                else
                {   //se busca el libro a editar
                    var temp = listado.FirstOrDefault(m => m.ISBN == id);
                    listado.Remove(temp); //se quita del listado
                    listado.Add(libro); //se agrega el nuevo libro

                    //se ubica al usuario dentro del listado libros
                    return RedirectToAction("Index", "libros");
                }
            }
        }


        //PROCESO PARA ELIMINAR UN LIBRO
        [HttpGet]
        public IActionResult Delete(int id) //parametro ID almacena el valor del ISBN
        {   
            //se busca el libro que se desea eliminar
            var temp = listado.FirstOrDefault(t => t.ISBN == id);

            //se envia la información del libro para confirmar la eliminacion
            return View(temp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int? id)
        {   //se busca el libro que vamos a eliminar
            var temp = listado.FirstOrDefault( t => t.ISBN == id);

            //se elimina de la lista
            listado.Remove(temp);

            //ubicamos al usuari dentro del listado de libros
            return RedirectToAction("Index", "Libros");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {   //se busca el libro dentro del listado
            var temp = listado.FirstOrDefault(r => r.ISBN == id);

            //se utiiza una expresión Lambda c#
            return temp != null ? View(temp) : View(null);
        }
    }
}
