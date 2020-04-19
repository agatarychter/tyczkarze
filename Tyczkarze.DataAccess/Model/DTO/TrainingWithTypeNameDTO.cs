using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class TrainingWithTypeNameDTO
    {
        public TrainingWithTypeNameDTO(int IdTraining, DateTime? DateOfTraining, string NameOfType, int IdTrainingType)
        {
            this.IdTraining = IdTraining;
            this.DateOfTraining = DateOfTraining.HasValue ? DateOfTraining.Value.ToShortDateString() : null;
            this.NameOfType = NameOfType;
            this.IdTrainingType = IdTrainingType; 
        }
        public int IdTraining { get; set; }

        public string DateOfTraining { get; set; }

        public string NameOfType { get; set; }

        public int ExerciseCount { get; set; }

        public int IdTrainingType { get; set; }
    }
}
