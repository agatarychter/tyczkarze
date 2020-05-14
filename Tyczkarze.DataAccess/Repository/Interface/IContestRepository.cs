using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.DataAccess.Repository.Interface
{
    public interface IContestRepository : IRepository<Contest>
    {
        Contest GetContestByCompetitionID(Int32 id);
        Dictionary<string, List<ContestWithCompetitiontDTO>> GetDictionaryContestForAthlete(int idAthlete);
    }
}
