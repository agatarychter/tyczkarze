using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.DataAccess.Repository.Interface
{
    public interface ITrainingRepository : IRepository<Training>
    {
        IEnumerable<Training> GetAllByIdAthlete(int idAthlete);
        Dictionary<string, List<TrainingWithTypeNameDTO>> GetAllWithTypeForAthlete(int idAthlete);
    }
}
