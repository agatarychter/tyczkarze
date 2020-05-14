using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.DataAccess.Repository.Interface
{ 
    public interface IPoleRepository : IRepository<Pole>
    {
        IEnumerable<Pole> GetAllByIdAthlete(int idAthlete);
    }
}
