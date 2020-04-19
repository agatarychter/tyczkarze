using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model
{
    public class Training
    {
        [Key]
        public int IdTraining { get; set; }

        [Required]
        public DateTime TrainingDateTime { get; set; }

        [Required]
        public int IdTrainingType { get; set; }

        [Required]
        public int IdAthlete { get; set; }        

        public ICollection<ExerciseDone> ExerciseDones { get; set; }
    }
}
