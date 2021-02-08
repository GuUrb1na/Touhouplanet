using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Touhouplanet.Models
{
    public class Touhou
    {
        
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Especie { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Habilidad { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Ocupacion { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Ubicacion { get; set; }
 
        public string Imagen { get; set; }

    }
}
