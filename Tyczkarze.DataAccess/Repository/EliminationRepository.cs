using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class EliminationRepository : IEliminationRepository
    {
        private readonly ApplicationDbContext _context;

        public EliminationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Elimination Add(Elimination entity)
        {
            _context.Elimination.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var elimination = _context.Elimination.Where(c => c.IdElimination == Id).FirstOrDefault();
            _context.Elimination.Remove(elimination);
            _context.SaveChanges();
        }

        public Elimination FindById(int Id)
        {
            return _context.Elimination.Where(x => x.IdElimination == Id).FirstOrDefault();
        }

        public IEnumerable<Elimination> GetAll()
        {
            return _context.Elimination.ToList();
        }

        public Elimination GetEliminationByCompetitionID(int id)
        {
           return _context.Elimination.Where(x => x.IdCompetition == id).FirstOrDefault();
        }

        public Elimination Update(Elimination elimination)
        {
            var obj = FindById(elimination.IdElimination);
            if (obj == null)
                return null;
            else
            {

                obj = elimination;
                _context.SaveChanges();
                return obj;
            }
        }
    }
}
