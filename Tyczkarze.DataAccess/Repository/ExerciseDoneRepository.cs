using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class ExerciseDoneRepository : IExerciseDoneRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseDoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public ExerciseDone Add(ExerciseDone entity)
        {
            _context.ExerciseDone.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var toDelete = FindById(Id);
            _context.ExerciseDone.Remove(toDelete);
            _context.SaveChanges();

        }

        public ExerciseDone FindById(int Id)
        {
            return _context.ExerciseDone.Where(x => x.IdExerciseDone == Id).FirstOrDefault();
        }

        public IEnumerable<ExerciseDone> GetAll()
        {
            return _context.ExerciseDone.ToList();
        }

        public ExerciseDone Update(ExerciseDone entity)
        {
            throw new NotImplementedException();
        }
    }
}
