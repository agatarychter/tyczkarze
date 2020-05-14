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
    public class TrainingTypeRepository : ITrainingTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TrainingType Add(TrainingType entity)
        {
            _context.TrainingType.Add(entity);
            _context.SaveChanges();
            return entity; 
        }

        public void Delete(int Id)
        {
            var trainingType = FindById(Id);
            _context.TrainingType.Remove(trainingType);
            _context.SaveChanges();
        }

        public TrainingType FindById(int Id)
        {
            return _context.TrainingType.Where(x => x.IdTrainingType == Id).FirstOrDefault();
        }

        public IEnumerable<TrainingType> GetAll()
        {
            return _context.TrainingType.ToList();
        }

        public TrainingType Update(TrainingType entity)
        {
            var obj = FindById(entity.IdTrainingType);
            if (obj == null)
                return null;
            else
            {
                obj = entity;
                _context.SaveChanges();
                return obj;
            }
        }
    }
}
