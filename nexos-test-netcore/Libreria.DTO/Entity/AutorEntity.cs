using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTO.Entity
{
    public class AutorEntity
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string ciudad { get; set; }
        public string correo { get; set; }
    }
}
