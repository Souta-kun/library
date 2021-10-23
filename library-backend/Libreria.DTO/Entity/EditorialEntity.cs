using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTO.Entity
{
    public class EditorialEntity
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string DireccionCorrespondencia { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int MaxLibroRegistrado { get; set; }
    }
}
