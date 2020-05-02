using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class CompetitionAgeCategory
    {
        [Key]
        public int IdAgeCategory { get; set; }

        [Required]
        public string NameAgeCategory { get; set; }

        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public string Description { get; set; }

        public ICollection<Competition> Competitions { get; set; }

    }
}
