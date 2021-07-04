using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTO.Entity
{
    public class EditorialEntity
    {
        [Key]
        public int id     { get; set; }
        public string nombre { get; set; }
        public string direccionCorrespondencia { get; set; }
        public string telefono { get; set; }
        public string correo   { get; set; }
        public int maxLibroRegistrado { get; set; }
    }
}
