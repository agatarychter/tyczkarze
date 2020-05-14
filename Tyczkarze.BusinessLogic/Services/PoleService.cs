using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;
using Tyczkarze.DataAccess.Repository;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.BusinessLogic.Services
{
    public class PoleService : IPoleService
    {
        private readonly ApplicationDbContext _context;

        private readonly IPoleRepository poleRepository;
        private readonly ITrainingService trainingSerivice;

        public PoleService(ApplicationDbContext context)
        {
            poleRepository = new PoleRepository(context);
            trainingSerivice = new TrainingService(context);
            _context = context;
        }
    

        public Pole Add(Pole entity)
        {
            var obj = poleRepository.Add(entity);
            return obj;
        }

        public void Delete(int Id)
        {
            poleRepository.Delete(Id);
        }

        public Pole FindById(int Id)
        {
            return poleRepository.FindById(Id);
        }

        public IEnumerable<Pole> GetAll()
        {
            return poleRepository.GetAll();
        }

        public IEnumerable<Pole> GetAllByIdAthlete(int idAthlete)
        {
            return poleRepository.GetAllByIdAthlete(idAthlete);
        }

        
        public IEnumerable<PoleChartDTO> GetPolesForChart(int id)
        {
            var poles = GetAllByIdAthlete(id);
            var result = new List<PoleChartDTO>();
           
            var allExercisesAthelete = trainingSerivice.GetAllExerciseForAthele(id);
            foreach (var pole in poles)
            {               
                var counter = allExercisesAthelete.Where(x => x.IdPole == pole.IdPole).Count();
                if (counter != 0)
                    result.Add(new PoleChartDTO() { Name = pole.NameByAthlete, Count = counter });
            }
            return result;
        }

        public IEnumerable<PoleChartDTO> GetPolesForChartLastMonth(int idAthlete)
        {
            var poles = GetAllByIdAthlete(idAthlete);
            ITrainingRepository trainingRepository = new TrainingRepository(context: _context);

            var monthTrainings = trainingSerivice.GetLast30DaysJumpTraining(idAthlete);
            var allExercisesAthelete = trainingSerivice.GetAllExerciseForAthele(idAthlete);
            var result = new List<PoleChartDTO>();
            if (poles != null && monthTrainings != null)
            {
                foreach (var pole in poles)
                {
                    var counter = allExercisesAthelete.Where(x => x.IdPole == pole.IdPole && monthTrainings.Contains(x.IdTraining)).Count();
                    if (counter != 0)
                        result.Add(new PoleChartDTO() { Name = pole.NameByAthlete, Count = counter });
                }
            }
            return result;
        }

        public IEnumerable<PoleChartDTO> GetPolesForChartLastTraining(int idAthlete)
        {
            ITrainingRepository trainingRepository = new TrainingRepository(context: _context);
            var poles = GetAllByIdAthlete(idAthlete);
            var lastTraining = trainingSerivice.GetLastJumpTraining(idAthlete);
            var result = new List<PoleChartDTO>();
            var allExercisesAthelete = trainingSerivice.GetAllExerciseForAthele(idAthlete);
            if (poles != null && lastTraining != null)
            {
                foreach (var pole in poles)
                {
                    var counter = allExercisesAthelete.Where(x => x.IdPole == pole.IdPole && x.IdTraining == lastTraining.IdTraining).Count();
                    if (counter != 0)
                        result.Add(new PoleChartDTO() { Name = pole.NameByAthlete, Count = counter });
                }
            }
            return result;
        }

        public Pole Update(Pole pole)
        {
            var obj = FindById(pole.IdPole);
            if (obj == null)
                return null;
            else
            {
                obj.Name = pole.Name;
                obj.NameByAthlete = pole.NameByAthlete;
                obj.Color = pole.Color;
                obj.Hardness = pole.Hardness;
                obj.Length = pole.Length;
                obj.Manufacturer = pole.Manufacturer;
                obj.Note = pole.Note;
                obj.Type = pole.Type;
                var result = poleRepository.Update(obj);
                return result;
            }
        }
    }
}
