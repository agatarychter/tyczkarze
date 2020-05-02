using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class JumpDTO
    {
        public decimal Height { get; set; }

        public string CompetitionName { get; set; }

        public bool IsContest { get; set; }
        public bool IsElimination { get; set; }

        public DateTime DateOfRecord { get; set; }
    }
}
