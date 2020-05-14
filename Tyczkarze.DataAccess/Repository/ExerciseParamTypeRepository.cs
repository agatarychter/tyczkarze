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
    public class ExerciseParamTypeRepository : IExerciseParamTypeRepository
    {

        private readonly ApplicationDbContext _context;

        public ExerciseParamTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExerciseParamType Add(ExerciseParamType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ExerciseParamType FindById(int Id)
        {
            return _context.ExerciseParamType.Where(x => x.IdParamType == Id).FirstOrDefault();
        }

        public IEnumerable<ExerciseParamType> GetAll()
        {
            return _context.ExerciseParamType.ToList();
        }

        public ExerciseParamType Update(ExerciseParamType entity)
        {
            throw new NotImplementedException();
        }
    }
}
