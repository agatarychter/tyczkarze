using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface IAthleteService
    {
        
        Athlete VerifyAthlete(AthleteLoginDTO user);
        Athlete GetByEmail(string email);
        Athlete GetByGuid(string guid);
        Athlete RemoveAthleteGuid(Int32 id);
        Athlete VerifyAthleteByGuid(String guid);
        IEnumerable<Athlete> GetAll();
        Athlete FindById(int id);
        Athlete Update(Athlete athlete);
        Athlete Add(Athlete athlete);
    }
}
