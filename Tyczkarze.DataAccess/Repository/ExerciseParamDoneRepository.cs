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
    public class ExerciseParamDoneRepository : IExerciseParamDoneRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseParamDoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ExerciseParamDone Add(ExerciseParamDone entity)
        {
            _context.ExerciseParamDone.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var toDelete = FindById(Id);
            _context.ExerciseParamDone.Remove(toDelete);
            _context.SaveChanges();
        }

        public ExerciseParamDone FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseParamDone> GetAll()
        {
            return _context.ExerciseParamDone.ToList();
        }

        public ExerciseParamDone Update(ExerciseParamDone entity)
        {
            throw new NotImplementedException();
        }
    }
}
