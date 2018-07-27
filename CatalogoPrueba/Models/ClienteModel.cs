using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatalogoPrueba.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {
            _id = 0;
            Razon_social = string.Empty;
            Nombre_comercial = string.Empty;
            RFC = string.Empty;
            CURP = string.Empty;
            direccion = string.Empty;
            
        }
        [DisplayName("ID")]
        [Required(ErrorMessage = "Se requiere el ID")]
        public int _id { get; set; }

        [DisplayName("Razon Social")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="No mas de 50 caracteres")]
        public string Razon_social { get; set; }

        [DisplayName("Nombre Comercial")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No mas de 50 caracteres")]
        public string Nombre_comercial { get; set; }

        [DisplayName("RFC")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(13, MinimumLength = 3, ErrorMessage = "No mas de 13 caracteres")]
        public string RFC { get; set; }

        [DisplayName("CURP")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(18, MinimumLength = 3, ErrorMessage = "No mas de 18 caracteres")]
        public string CURP { get; set; }

        [DisplayName("direccion")]
        [Required(ErrorMessage = "Se requiere este campo")]
        [StringLength(13, MinimumLength = 3, ErrorMessage = "No mas de 50 caracteres")]
        public string direccion { get; set; }
    }
}