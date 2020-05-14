using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
namespace Tyczkarze.DataAccess.Repository.Interface
{
    public interface IJumpRepository : IRepository<Jump>
    {
       
        IEnumerable<Jump> GetAllForContest(Int32 idContest);
        IEnumerable<Jump> GetAllForElimination(Int32 idElimination);

        
    }
}
