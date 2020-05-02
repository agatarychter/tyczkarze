using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class CompetitionWithAgeAndLevelDTO
    {

        /*public CompetitionWithAgeAndLevel(int IdCompetition, int ResultType, DateTime? BeginDate = null, DateTime? EndDate = null, string Country = null, string City = null, string Name = null, string NameAgeCategory = null, string LevelName = null, DateTime? ContestDate = null, string DescriptionContest = null, string DescriptionElimination = null, int? IdContest = null, int? IdElimination = null)
        {
            this.IdCompetition = IdCompetition;
            this.BeginDate = BeginDate.HasValue ? BeginDate.Value.ToShortDateString() : null;
            this.EndDate = EndDate.HasValue ? EndDate.Value.ToShortDateString() : null;
            this.Country = Country;
            this.City = City;
            this.Name = Name;
            this.NameAgeCategory = NameAgeCategory;
            this.LevelName = LevelName;
            this.ContestDate = ContestDate.HasValue ? ContestDate.Value.ToShortDateString() : null;
            this.DescriptionContest = DescriptionContest;
            this.DescriptionElimination = DescriptionElimination;
            this.IdContest = IdContest;
            this.IdElimination = IdElimination;

        }*/

        public int IdCompetition { get; set; }

        public string BeginDate { get; set; }

        public string EndDate { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string NameAgeCategory { get; set; }

        public string LevelName { get; set; }

        public string ContestDate { get; set; }

        public string DescriptionContest { get; set; }

        public string DescriptionElimination { get; set; }

        public int? IdContest { get; set; }

        public int? IdElimination { get; set; }

        public int ResultType { get; set; }

        public string CommonDate { get; set; }
    }
}
