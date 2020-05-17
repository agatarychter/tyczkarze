using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class PoleRepository : IPoleRepository
    {
        private readonly ApplicationDbContext _context;
        public PoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Pole Add(Pole entity)
        {
            var obj = _context.Pole.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var pole = FindById(id)
            if(pole != null)
            {
                _context.Pole.Remove(pole);
            }            
            _context.SaveChanges();
        }

        public Pole FindById(int Id)
        {
            return _context.Pole.Where(x => x.IdPole == Id).FirstOrDefault();
        }

        public IEnumerable<Pole> GetAll()
        {
            return _context.Pole.ToList();
        }

        public IEnumerable<Pole> GetAllByIdAthlete(int idAthlete)
        {
            return _context.Pole.Where(x => x.IdAthlete==idAthlete).ToList();
        }       

        public Pole Update(Pole pole)
        {
            var obj = FindById(pole.IdPole);
            if (obj == null)
                return null;
            else
            {
                obj = pole;
                _context.SaveChanges();
                return obj;
            }
        }
    }
}
