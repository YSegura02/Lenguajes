using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace AppBibliotecaWeb.Models
{
    public class Libro
    {
        public int ISBN { get; set; }

        public string Titulo { get; set; }

        public string Editorial { get; set; }

        public decimal PrecioVenta { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public string Foto { get; set; }

        public char Estado { get; set; }
    
    }
}
