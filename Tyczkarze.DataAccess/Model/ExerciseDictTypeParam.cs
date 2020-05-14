using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class ExerciseDictTypeParam
    {
        [Key]
        public int IdExerciseType { get; set; }

        [Key]
        public int IdExerciseParamType { get; set; }

        public ExerciseType ExerciseType { get; set; }
        public ExerciseParamType ExerciseParamType { get; set; }
    }
}
