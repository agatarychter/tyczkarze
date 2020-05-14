using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ApplicationDbContext _context;

        public TrainingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Training Add(Training entity)
        {
            _context.Training.Add(entity);
            _context.SaveChanges();
            return entity;
        }        

        public void Delete(int Id)
        {
            var training = _context.Training.Where(c => c.IdTraining == Id).FirstOrDefault();
            var exercises = _context.ExerciseDone.Where(x => x.IdTraining == Id).ToList();
            foreach (var exer in exercises)
            {
                _context.ExerciseDone.Remove(exer);
            }
            _context.Training.Remove(training);
            _context.SaveChanges();
        }

        public Training FindById(int Id)
        {
            return _context.Training.Where(x => x.IdTraining == Id).FirstOrDefault();
        }

        public IEnumerable<Training> GetAll()
        {
            return _context.Training.ToList();
        }

        public IEnumerable<Training> GetAllByIdAthlete(int idAthlete)
        {
            return _context.Training.Where(x => x.IdAthlete == idAthlete).ToList();
        }
    
        public Training Update(Training entity)
        {
            var obj = FindById(entity.IdTraining);
            if (obj == null)
                return null;
            else
            {
                obj = entity;
                _context.SaveChanges();
                return obj;
            }
        }


        public Dictionary<string, List<TrainingWithTypeNameDTO>> GetAllWithTypeForAthlete(int idAthlete)
        {
            var result = (from m1 in _context.Training
                          join m2 in _context.TrainingType
                           on m1.IdTrainingType equals m2.IdTrainingType into joinTable
                          where m1.IdAthlete == idAthlete
                          from x in joinTable.DefaultIfEmpty()
                          select new TrainingWithTypeNameDTO
                          (
                              m1.IdTraining,
                              m1.TrainingDateTime,
                              x.TrainingName,
                              m1.IdTrainingType
                          )).ToList();
            foreach (var t in result)
            {
                t.ExerciseCount = _context.ExerciseDone.Where(x => x.IdTraining == t.IdTraining).Count();
            }
            var allDates = result.Select(x => x.DateOfTraining).Distinct();
            var map = new Dictionary<string, List<TrainingWithTypeNameDTO>>();
            foreach (var date in allDates)
            {
                if (!String.IsNullOrEmpty(date))
                {
                    var allTrainingsFromDate = result.Where(x => x.DateOfTraining == date).ToList();
                    map.Add(date, allTrainingsFromDate);
                }

            }
            return map;
        }

    }
}
