using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class Elimination
    {
        [Key]
        public int IdElimination { get; set; }

        [Required]
        public DateTime EliminationDate { get; set; }

        public string Note { get; set; }

        [Required]
        public int IdCompetition { get; set; }
        
        public ICollection<Jump> Jumps { get; set; }
    }
}
