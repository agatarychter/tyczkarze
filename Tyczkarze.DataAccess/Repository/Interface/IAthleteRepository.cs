using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.DataAccess.Repository.Interface
{
    public interface IAthleteRepository : IRepository<Athlete>
    {
        Athlete GetByEmail(string email);
        Athlete GetByGuid(string guid);
    }
}
