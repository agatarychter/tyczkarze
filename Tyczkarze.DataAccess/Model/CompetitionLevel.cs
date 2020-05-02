using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class CompetitionLevel
    {
        [Key]
        public int IdLevel { get; set; }

        [Required]
        public string LevelName { get; set; }

        public string Description { get; set; }
        
        public ICollection<Competition> Competitions { get; set; }
    }
}
