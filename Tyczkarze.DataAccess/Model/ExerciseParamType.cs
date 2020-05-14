using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class ExerciseParamType
    {
        [Key]
        public int IdParamType { get; set; }

        [Required]
        public string ParamName { get; set; }

        [Required]
        public string ParamType { get; set; }

        public bool IsObligatory { get; set; }

        public virtual ICollection<ExerciseDictTypeParam> ExerciseDictTypeParams { get; set; }
        //public virtual ICollection<ExerciseType> ExerciseTypes { get; set; }
    }
}
