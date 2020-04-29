using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface IContestService
    {
        Contest GetContestByCompetitionID(Int32 id);
        Dictionary<string, List<ContestWithCompetitiontDTO>> GetDictionaryContestForAthlete(Int32 idAthlete);
        Contest FindById(int idContest);
        void Delete(int idContest);
        Contest Update(Contest contest);
        Contest Add(Contest contest);
    }
}
