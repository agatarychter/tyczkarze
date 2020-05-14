using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ITrainingService trainingSevice;
        private readonly ApplicationDbContext _context;

        public ExerciseController(ApplicationDbContext context)
        {
            trainingSevice = new TrainingService(context);
            _context = context;
        }

        /*
        // GET: api/exercise/id(idTraining)
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercisesByTrainingID(Int32 id)
        {
            return await _context.Exercise.Where(x => x.IdTraining == id).ToListAsync();
        }*/


        // GET: api/exercise/id(idTraining)
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<ExerciseDTO>> GetExercisesByTrainingID(Int32 id)
        {
            return Ok(trainingSevice.GetExercisesByTrainingID(id));        
        }

            

        /*// GET: api/Exercise/idExercise
        [HttpDelete]
        public ActionResult<Exercise> DeleteExercise(Int32 idExercise)
        {
            var exercise = _context.Exercise.Where(c => c.IdExercise == idExercise).FirstOrDefault();
            _context.Exercise.Remove(exercise);
            _context.SaveChanges();
            return Ok();
        }*/

        // GET: api/Exercise/idExercise
        [HttpDelete]
        public ActionResult<ExerciseDTO> DeleteExercise(Int32 idExercise)
        {
            trainingSevice.DeleteExercise(idExercise); 
            return Ok();
        }

        /* // POST: api/Exercise
         [HttpPost]
         public async Task<ActionResult<Exercise>> AddExercise(Exercise exercise)
         {
             Exercise obj;
             if (exercise.IdExercise != 0)
             {
                 obj = _context.Exercise.Where(x => x.IdExercise == exercise.IdExercise).FirstOrDefault();
                 if (obj == null)
                     return NoContent();
                 else
                 {
                     obj.Distance = exercise.Distance;
                     obj.ExerciseCount = exercise.ExerciseCount;
                     obj.ExerciseName = exercise.ExerciseName;
                     obj.Height = exercise.Height;
                     obj.IdPole = exercise.IdPole;

                     obj.JumpType = exercise.JumpType;
                     obj.Note = exercise.Note;
                     obj.SeriesCount = exercise.SeriesCount;
                     obj.Spikes = exercise.Spikes;
                     obj.StepsCount = exercise.StepsCount;
                     obj.Time = exercise.Time;
                     obj.Weight = exercise.Weight;
                     obj.IdTraining = obj.IdTraining;
                 }
             }
             else
             {
                 obj = _context.Exercise.Add(exercise).Entity;
             }

             await _context.SaveChangesAsync();
             return Ok(obj);
         }*/

        // POST: api/Exercise
        [HttpPost]
        public ActionResult<ExerciseDTO> AddExercise(ExerciseDTO exercise)
        {
            if (exercise.IdExercise != 0)
            {
                trainingSevice.UpdateExercise(exercise);
            }
            else
            {
                trainingSevice.AddExercise(exercise);                    
            }
            
            return Ok();
        }

        
    }
}
