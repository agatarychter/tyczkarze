using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class ExerciseDone
    {
        [Key]
        public int IdExerciseDone { get; set; }

        [Required]
        public int IdTraining { get; set; }


        public ICollection<ExerciseParamDone> ExerciseParamDones { get; set; }
    }
}
