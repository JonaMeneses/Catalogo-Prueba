using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogoPrueba.Models
{
    public class ContactoModel
    {
        [DisplayName("ID")]
        [Required(ErrorMessage = "Se requiere el ID")]
        public int _id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No mas de 50 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido paterno")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No mas de 50 caracteres")]
        public string Apellido_paterno { get; set; }

        [DisplayName("Apellido materno")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No mas de 50 caracteres")]
        public string Apellido_materno { get; set; }

        [DisplayName("Telefono")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No mas de 12 caracteres")]
        public string Telefono { get; set; }

        [DisplayName("ID cliente")]
        [Required(ErrorMessage = "Se requiere el ID")]
        public int id_cliente { get; set; }


    }
}