using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libreria.DTO.Entity
{
    public class LibroEntity
    {
        [Key]
        public int id { get; set; }
        public string titulo { get; set; }
        public int anio { get; set; }
        public string genero { get; set; }
        public int npaginas { get; set; }
        public int editorial { get; set; }
        public int autor { get; set; }
    }
}
