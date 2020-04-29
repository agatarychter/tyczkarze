using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface ICompetitionService
    {
        IEnumerable<CompetitionAgeCategory> GetAllAgeCategory();
        IEnumerable<CompetitionLevel> GetAllLevels();

        IEnumerable<Competition> GetAllForAthlete(Int32 id);

        Dictionary<string, List<CompetitionWithAgeAndLevelDTO>> GetDictionaryCompetitionForAthlete(Int32 idAthlete);

        Competition GetFirstCompetition(Int32 idAthlete);
        void Delete(int idCompetition);
        Competition FindById(int idCompetition);
        Competition Update(Competition competiton);
        Competition Add(Competition competiton);
    }
}
