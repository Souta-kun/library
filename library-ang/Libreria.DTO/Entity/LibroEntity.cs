using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Libreria.DTO.Entity
{
    public class LibroEntity
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Anio { get; set; }
        public string Genero { get; set; }
        public int Npaginas { get; set; }
        public int EditorialId { get; set; }
        public int AutorId { get; set; }
        [NotMapped]
        public string Editorial { get; set; }
        [NotMapped]
        public string Autor { get; set; }

    }
}
