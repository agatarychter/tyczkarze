using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class AthleteRepository : IAthleteRepository
    {

        private readonly ApplicationDbContext _context;

        public AthleteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Athlete Add(Athlete entity)
        {
            _context.Athlete.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Athlete FindById(int Id)
        {
            return _context.Athlete.Where(x => x.IdAthlete == Id).FirstOrDefault();
        }

        public IEnumerable<Athlete> GetAll()
        {
            return _context.Athlete.ToList();
        }

        public Athlete GetByEmail(string email)
        {
            return _context.Athlete.Where(x => x.Email == email).FirstOrDefault();
        }

        public Athlete GetByGuid(string guid)
        {
            return _context.Athlete.Where(x => x.GUID == guid).FirstOrDefault();
        }

        public Athlete Update(Athlete athlete)
        {
            var obj = FindById(athlete.IdAthlete);
            if (obj == null)
                return null;
            else
            {
                obj = athlete;
                _context.SaveChanges();
                return obj;
            }
        }

    }
}
