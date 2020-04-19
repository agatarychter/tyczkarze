using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{

    public class Athlete
    {
        [Key]
        public Int32 IdAthlete { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string GUID { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Height { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; }

        public ICollection<Training> Trainings { get; set; }
        public ICollection<Pole> Poles { get; set; }
        public ICollection<Competition> Competitions { get; set; }

    }
}
