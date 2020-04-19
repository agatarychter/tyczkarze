using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface ITrainingService
    {
        IEnumerable<Training> GetAllByIdAthlete(int idAthlete);
        Training GetFirstTraining(Int32 idAthlete);
        Training GetLastJumpTraining(Int32 idAthlete);
        IEnumerable<int> GetLast30DaysJumpTraining(Int32 idAthlete);
        int GetCountTraining(Int32 idAthlete);
        int GetCountMonthTraining(Int32 idAthlete);
        int GetCountWeekTraining(Int32 idAthlete);        
        IEnumerable<Training> GetAllByAthleteLast30Days(int idAthlete);

        #region wykresy

        IEnumerable<TrainingTypeCountChartDTO> GetCountMonthByTypeTraining(Int32 idAthlete);
        Dictionary<string, List<TrainingWithTypeNameDTO>> GetAllWithTypeForAthlete(Int32 idAthlete);

        #endregion

        #region typ treningu
        IEnumerable<TrainingType> GetAllTrainingTypes();
        #endregion
        #region ćwiczenia
        ExerciseDTO DeleteExercise(Int32 idExercise);
        IEnumerable<ExerciseDTO> GetExercisesByTrainingID(Int32 id);
        Training FindById(int idTraining);
        ExerciseDTO AddExercise(ExerciseDTO exercise);
        ExerciseDTO UpdateExercise(ExerciseDTO exercise);
        IEnumerable<ExerciseDTO> GetAllExerciseForAthele(int IdAthlete);
        void Delete(int idTraining);
        Training Add(Training training);
        Training Update(Training training);
        #endregion
    }
}
