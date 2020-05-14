using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class ExerciseType
    {
        [Key]
        public int IdExerciseType { get; set; }

        [Required]
        public string ExerciseTypeName { get; set; }

        public string Description { get; set; }

        public ICollection<TrainingType> TrainingTypes { get; set; }

        public virtual ICollection<ExerciseDictTypeParam> ExerciseDictTypeParams { get; set; }
        //public virtual ICollection<ExerciseParamType> ExerciseParamTypes { get; set; }
    }
}
