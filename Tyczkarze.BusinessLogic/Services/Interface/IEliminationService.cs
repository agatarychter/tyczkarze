using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface IEliminationService
    {
        Elimination GetEliminationByCompetitionID(Int32 id);
        void Delete(int idElimination);
        Elimination Add(Elimination elimination);
        Elimination Update(Elimination elimination);
        Elimination FindById(int idElimination);
    }
}
