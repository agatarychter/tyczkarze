using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.DataAccess.Repository.Interface
{
    public interface ICompetitionRepository : IRepository<Competition>
    {
        IEnumerable<Competition> GetAllForAthlete(Int32 id);
        Dictionary<string, List<CompetitionWithAgeAndLevelDTO>> GetDictionaryCompetitionForAthlete(int idAthlete);
    }
}
