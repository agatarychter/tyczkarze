using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class Pole
    {
        [Key]
        public int IdPole {get; set;}

        public string Name { get; set; }

        [Required]
        public string NameByAthlete { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Hardness { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Length { get; set; }

        public string Manufacturer { get; set; }

        public string Note { get; set; }

        [Required]
        public int IdAthlete { get; set; }
    }
}
