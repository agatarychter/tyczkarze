using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class TrainingType
    {
        [Key]
        public int IdTrainingType { get; set; }

        [Required]
        public string TrainingName { get; set; }

        public string Description { get; set; }

        [Required]
        public int IdExerciseType { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}
