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
    public class ExerciseDictTypeParamRepository : IExerciseDictTypeParamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExerciseDictTypeParamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ExerciseDictTypeParam Add(ExerciseDictTypeParam entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ExerciseDictTypeParam FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExerciseDictTypeParam> GetAll()
        {
            return _context.ExerciseDictTypeParam.ToList();
        }

        public ExerciseDictTypeParam Update(ExerciseDictTypeParam entity)
        {
            throw new NotImplementedException();
        }
    }
}
