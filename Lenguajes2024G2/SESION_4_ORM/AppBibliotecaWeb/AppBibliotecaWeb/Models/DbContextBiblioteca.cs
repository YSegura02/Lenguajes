using Microsoft.EntityFrameworkCore;

namespace AppBibliotecaWeb.Models
{
    public class DbContextBiblioteca : DbContext
    {
        //constructor con parametros utiliza el constructor de la clase padre
        public DbContextBiblioteca(DbContextOptions<DbContextBiblioteca> options) : base (options)
        {

        }

        //Se construye el DbSet para eñ catalogo de libros
        public DbSet<Libro> Libros { get; set; }

        //metdo encargado para inicializar el objet Modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().HasData(new Libro()
            {
                ISBN = 44,
                Titulo = "Lenguajes Programación",
                PrecioVenta = 25600,
                Editorial = "Puntarenas",
                Foto = "ND",
                FechaPublicacion = DateTime.Now,
                Estado = 'A'
            });
        }
    }//cierre class
}//cierre namespace
