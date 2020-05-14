using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class ExerciseParamDone
    {
        [Key]
        public int IdExerciseParam { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public int IdExerciseParamType { get; set; }

        [Required]
        public int IdExerciseDone { get; set; }

        [ForeignKey("IdExerciseParamType")]
        public ExerciseParamType ExerciseParamType { get; set; }

    }
}
