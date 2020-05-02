using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class Competition
    {
        [Key]
        public int IdCompetition { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Note { get; set; }

        public int? IdAgeCategory { get; set; }

        public int? IdLevel { get; set; }

        [Required]
        public int IdAthlete { get; set; }

        public ICollection<Contest> Contests { get; set; }
        public ICollection<Elimination> Eliminations { get; set; }
    }
}
