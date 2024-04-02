using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;

namespace AppBibliotecaWeb.Models
{
    public class Libro
    {
        [Key]
        [Required (ErrorMessage ="Ingresa el ISBN")]
        public int ISBN { get; set; }

        [Required (ErrorMessage ="Debe ingresar el título")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required (ErrorMessage ="Debe ingresar la editorial")]
        [DataType(DataType.Text)]
        [StringLength (100)]
        public string Editorial { get; set; }

        [Required (ErrorMessage ="Ingresa el precio venta.")]
        [Range(0,9999999.99)]
        public decimal PrecioVenta { get; set; }

        [Required (ErrorMessage ="Seleccione la fecha de publicacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime FechaPublicacion { get; set; }

        [Required (ErrorMessage ="Debe seleccionar la fotografía")]
        [DataType(DataType.Text)]
        public string Foto { get; set; }

        [Required (ErrorMessage ="Debe seleccionar un estado.")]
        public char Estado { get; set; }
    }//cierre de class
}//cierre de namespaces
