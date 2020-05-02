using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class ContestWithCompetitiontDTO
    {
        public string CompetitionName { get; set; }

        public string ContestDate { get; set; }

        public string Description { get; set; }

        public int IdContest { get; set; }

        public ContestWithCompetitiontDTO(int IdContest, string CompetitionName, DateTime? ContestDate, string Description)
        {
            this.IdContest = IdContest;
            this.CompetitionName = CompetitionName;
            this.ContestDate = ContestDate.HasValue ? ContestDate.Value.ToShortDateString() : null; ;
            this.Description = Description;
        }
    }
}
