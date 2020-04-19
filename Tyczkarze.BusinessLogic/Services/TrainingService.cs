using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class TrainingService : ITrainingService
    {
        private readonly ApplicationDbContext _context;

        private readonly ITrainingRepository trainingRepository;
        private readonly ITrainingTypeRepository trainingTypeRepository;
        private readonly IAthleteRepository athleteRepository;
        private readonly IExerciseDoneRepository exerciseDoneRepository;
        private readonly IExerciseParamDoneRepository exerciseParamDoneRepository;
        private readonly IExerciseParamTypeRepository exerciseParamTypeRepository;
        private readonly IExerciseDictTypeParamRepository exerciseDictTypeParamRepository;

        public TrainingService(ApplicationDbContext context)
        {
            trainingRepository = new TrainingRepository(context);
            trainingTypeRepository = new TrainingTypeRepository(context);
            athleteRepository = new AthleteRepository(context);
            exerciseDoneRepository = new ExerciseDoneRepository(context);
            exerciseParamDoneRepository = new ExerciseParamDoneRepository(context);
            exerciseParamTypeRepository = new ExerciseParamTypeRepository(context);
            exerciseDictTypeParamRepository = new ExerciseDictTypeParamRepository(context);
            _context = context;
        }

        public Training Add(Training entity)
        {
            var result = trainingRepository.Add(entity);
            return result;
        }        

        public void Delete(int Id)
        {
            trainingRepository.Delete(Id);
        }

        public Training FindById(int Id)
        {
            return trainingRepository.FindById(Id);
        }

        public IEnumerable<Training> GetAll()
        {
            return trainingRepository.GetAll();
        }

        public IEnumerable<Training> GetAllByAthleteLast30Days(int idAthlete)
        {
           return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x => x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddMonths(-1));
        }

        public IEnumerable<Training> GetAllByIdAthlete(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete);
        }

        public IEnumerable<TrainingType> GetAllTrainingTypes()
        {
            return trainingTypeRepository.GetAll();
        }

        public Training GetLastJumpTraining(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x => x.IdTrainingType == 9 && x.TrainingDateTime <= DateTime.Now).OrderByDescending(x => x.TrainingDateTime).FirstOrDefault();
        }

        public IEnumerable<int> GetLast30DaysJumpTraining(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x => x.IdTrainingType == 9 && x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Today.AddMonths(-1)).Select(x => x.IdTraining).ToList();
        }

        public Dictionary<string, List<TrainingWithTypeNameDTO>> GetAllWithTypeForAthlete(int idAthlete)
        {
            
            return trainingRepository.GetAllWithTypeForAthlete(idAthlete);
        }

        public IEnumerable<TrainingTypeCountChartDTO> GetCountMonthByTypeTraining(int idAthlete)
        {
            var trainings = GetAllByAthleteLast30Days(idAthlete);
            var types = trainingTypeRepository.GetAll();
            var atlhete = athleteRepository.FindById(idAthlete);
            List<TrainingTypeCountChartDTO> result = new List<TrainingTypeCountChartDTO>();
            var cos = atlhete.Trainings;
            foreach (var type in types)
            {
                if (type.IdTrainingType != 11 && type.IdTrainingType != 1)
                {
                    var counter = trainings.Where(x => x.IdTrainingType == type.IdTrainingType).Count();
                    result.Add(new TrainingTypeCountChartDTO() { Name = type.TrainingName, Count = counter });
                }
            }
            return result;
        }

        public int GetCountMonthTraining(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x => x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddMonths(-1)).Count();
        }

        public int GetCountTraining(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x => x.TrainingDateTime <= DateTime.Now).Count();
        }

        public int GetCountWeekTraining(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x =>x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddDays(-7)).Count();

        }

        public IEnumerable<ExerciseDTO> GetExercisesByTrainingID(int id)
        {
            var resultList = new List<ExerciseDTO>();

            //wykonane ćwiczenia
            var exerciseDone = exerciseDoneRepository.GetAll().Where(x => x.IdTraining == id).ToList();

            foreach (var exer in exerciseDone)
            {
                //jego parametry
                var paramsOfExerciseDone = exerciseParamDoneRepository.GetAll().Where(x => x.IdExerciseDone == exer.IdExerciseDone).ToList();
                ExerciseDTO result = new ExerciseDTO() { IdExercise = exer.IdExerciseDone, IdTraining = exer.IdTraining };
                MapParamsToObject(result, paramsOfExerciseDone);
                var toReturn = result;
                resultList.Add(toReturn);
            }

            return resultList;
        }

        public Training GetFirstTraining(int idAthlete)
        {
            return trainingRepository.GetAllByIdAthlete(idAthlete).Where(x => x.TrainingDateTime > DateTime.Now).OrderBy(x => x.TrainingDateTime).FirstOrDefault();
        }

        public Training Update(Training entity)
        {
            var obj = FindById(entity.IdTraining);
            if (obj == null)
                return null;
            else
            {
                obj.TrainingDateTime = entity.TrainingDateTime;
                var result = trainingRepository.Update(obj);
                return result;
            }
        }

        public ExerciseDTO DeleteExercise(int idExercise)
        {
            //var exercise = exerciseDoneRepository.FindById(idExercise);

            //_context.ExerciseDone.Remove(exercise);
            exerciseDoneRepository.Delete(idExercise);

            var paramsOfExercise = exerciseParamDoneRepository.GetAll().Where(x => x.IdExerciseDone == idExercise).ToList();
            foreach (var toDelete in paramsOfExercise)
            {
                exerciseParamDoneRepository.Delete(toDelete.IdExerciseParam);
                //_context.ExerciseParamDone.Remove(toDelete);
            }
            return null;
        }

        public ExerciseDTO AddExercise(ExerciseDTO exercise)
        {
            var trainingType = trainingRepository.FindById(exercise.IdTraining).IdTrainingType;
            var exerciseType = trainingTypeRepository.FindById(trainingType).IdExerciseType;

            var idExerciseDone = SaveExerciseDone(exercise);
            //var parametersIDs = _context.ExerciseDictTypeParam.Where(x => x.IdExerciseType == exerciseType).Select(y => y.IdExerciseParamType).ToList();
            var parametersIDs = exerciseDictTypeParamRepository.GetAll().Where(x => x.IdExerciseType == exerciseType).Select(y => y.IdExerciseParamType).ToList();
            //var parameters = _context.ExerciseParamType.Where(x => parametersIDs.Contains(x.IdParamType)).ToList();
            var parameters = exerciseParamTypeRepository.GetAll().Where(x => parametersIDs.Contains(x.IdParamType)).ToList();
            foreach (var par in parameters)
            {
                var value = GetValue(par, exercise);
                if (value != null)
                {
                    ExerciseParamDone toSave = new ExerciseParamDone() { Value = value.ToString(), IdExerciseDone = idExerciseDone, IdExerciseParamType = par.IdParamType };
                    exerciseParamDoneRepository.Add(toSave);
                }
            }
            return exercise;
        }

        public ExerciseDTO UpdateExercise(ExerciseDTO exercise)
        {
            var trainingType = trainingRepository.FindById(exercise.IdTraining).IdTrainingType;
            var exerciseType = trainingTypeRepository.FindById(trainingType).IdExerciseType;
            //var parametersIDs = _context.ExerciseDictTypeParam.Where(x => x.IdExerciseType == exerciseType).Select(y => y.IdExerciseParamType).ToList();
            var parametersIDs = exerciseDictTypeParamRepository.GetAll().Where(x => x.IdExerciseType == exerciseType).Select(y => y.IdExerciseParamType).ToList();
            //var parameters = _context.ExerciseParamType.Where(x => parametersIDs.Contains(x.IdParamType)).ToList();
            var parameters = exerciseParamTypeRepository.GetAll().Where(x => parametersIDs.Contains(x.IdParamType)).ToList();

            foreach (var par in parameters)
            {
                var editObj = exerciseParamDoneRepository.GetAll().Where(x => x.IdExerciseDone == exercise.IdExercise && x.IdExerciseParamType == par.IdParamType).FirstOrDefault();
                if (editObj == null)
                {
                    editObj = new ExerciseParamDone() { IdExerciseDone = exercise.IdExercise, IdExerciseParamType = par.IdParamType };
                    exerciseParamDoneRepository.Add(editObj);
                }
                var value = GetValue(par, exercise);
                if(value == null)
                {
                    exerciseParamDoneRepository.Delete(editObj.IdExerciseParam);
                    //_context.ExerciseParamDone.Remove(editObj);
                }
                else
                {
                    editObj.Value = value.ToString();
                }
                
            }

            return exercise;
        }

        #region ćwiczenia
        private void MapParamsToObject(ExerciseDTO result, List<ExerciseParamDone> paramsOfExerciseDone)
        {
            foreach (var param in paramsOfExerciseDone)
            {
                var nameOfParam = exerciseParamTypeRepository.FindById(param.IdExerciseParamType);
                    //exerciseParamTypeRepository.GetAll().Where(x => x.IdParamType == param.IdExerciseParamType).FirstOrDefault();
                SetValue(result, nameOfParam, param.Value);
            }
        }

        private void SetValue(ExerciseDTO result, ExerciseParamType nameOfParam, string value)
        {
            var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            var provider = new CultureInfo("en-US");
            switch (nameOfParam.ParamName)
            {
                case "ExerciseName":
                    result.ExerciseName = value;
                    break;
                case "Note":
                    result.Note = value;
                    break;
                case "SeriesCount":
                    result.SeriesCount = Int32.Parse(value);
                    break;
                case "Distance":
                    result.Distance = Int32.Parse(value);
                    break;
                case "Time":
                    result.Time = Decimal.Parse(value, style, provider);
                    break;
                case "Spikes":
                    result.Spikes = Boolean.Parse(value);
                    break;
                case "ExerciseCount":
                    result.ExerciseCount = Int32.Parse(value);
                    break;
                case "Weight":
                    result.Weight = Decimal.Parse(value, style, provider);
                    break;
                case "IdJumpType":
                    result.JumpType = Int32.Parse(value);
                    break;
                case "Height":
                    result.Height = Decimal.Parse(value, style, provider);
                    break;
                case "StepsCount":
                    result.StepsCount = Int32.Parse(value);
                    break;
                case "IdPole":
                    result.IdPole = Int32.Parse(value);
                    break;
            }
        }

        private object GetValue(ExerciseParamType par, ExerciseDTO exercise)
        {
            switch (par.ParamName.ToString())
            {
                case "ExerciseName":
                    return exercise.ExerciseName;
                case "Note":
                    return exercise.Note;
                case "SeriesCount":
                    return exercise.SeriesCount;
                case "Distance":
                    return exercise.Distance;
                case "Time":
                    return exercise.Time;
                case "Spikes":
                    return exercise.Spikes;
                case "ExerciseCount":
                    return exercise.ExerciseCount;
                case "Weight":
                    return exercise.Weight;
                case "IdJumpType":
                    return exercise.JumpType;
                case "Height":
                    return exercise.Height;
                case "StepsCount":
                    return exercise.StepsCount;
                case "IdPole":
                    return exercise.IdPole;
                default:
                    return "";

            }
        }

        private int SaveExerciseDone(ExerciseDTO exercise)
        {
            var newToSave = new ExerciseDone() { IdTraining = exercise.IdTraining };
            var result = exerciseDoneRepository.Add(newToSave);
            int value = newToSave.IdExerciseDone;
            return value;
        }

        public IEnumerable<ExerciseDTO> GetAllExerciseForAthele(int IdAthlete)
        {
            var resultList = new List<ExerciseDTO>();

            var allTrainingsAthlete = GetAllByIdAthlete(IdAthlete);

            foreach(var training in allTrainingsAthlete)
            {
                //wykonane ćwiczenia
                var exerciseDone = exerciseDoneRepository.GetAll().Where(x => x.IdTraining == training.IdTraining).ToList();

                foreach (var exer in exerciseDone)
                {
                    //jego parametry
                    var paramsOfExerciseDone = exerciseParamDoneRepository.GetAll().Where(x => x.IdExerciseDone == exer.IdExerciseDone).ToList();
                    ExerciseDTO result = new ExerciseDTO() { IdExercise = exer.IdExerciseDone, IdTraining = exer.IdTraining };
                    MapParamsToObject(result, paramsOfExerciseDone);
                    var toReturn = result;
                    resultList.Add(toReturn);
                }
            }       
            return resultList;
        }

        


        #endregion
    }
}
