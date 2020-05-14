using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class ExerciseDTO
    {

        public int IdExercise { get; set; }
        public string ExerciseName { get; set; }
        public int? SeriesCount { get; set; }
        public int? Distance { get; set; }
        public decimal? Time { get; set; }
        public bool? Spikes { get; set; }
        public int? ExerciseCount { get; set; }
        public decimal? Weight { get; set; }
        public int? JumpType { get; set; }
        public decimal? Height { get; set; }
        public int? StepsCount { get; set; }
        public int? IdPole { get; set; }
        public string Note { get; set; }
        public int IdTraining { get; set; }
    }
}
