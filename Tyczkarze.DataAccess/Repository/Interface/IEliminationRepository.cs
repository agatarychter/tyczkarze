using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.DataAccess.Repository.Interface
{
    public interface IEliminationRepository : IRepository<Elimination>
    {
        Elimination GetEliminationByCompetitionID(Int32 id);
    }
}
