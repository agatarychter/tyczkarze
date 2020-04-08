using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {

        private readonly ITrainingService trainingService;
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            trainingService = new TrainingService(context);
            _context = context;
        }

        // GET: api/Training/idAthlete
        [HttpGet("{id}")]
        public IEnumerable<Training> GetAllForAthlete(Int32 id)
        {
            var result =  trainingService.GetAllByIdAthlete(id);
            return result;
        }

        // GET: api/Training?idTraining
        [HttpGet]
        [Route("trainings")]
        public Training GetById(Int32 idTraining)
        {
            return trainingService.FindById(idTraining);
            //return await _context.Training.Where(x => x.IdTraining == idTraining).FirstAsync();
        }

        // GET: api/Training?idAthlete=
        [HttpGet]
        public Dictionary<string, List<TrainingWithTypeNameDTO>> GetAllWithTypeForAthlete(Int32 idAthlete)
        {
            return trainingService.GetAllWithTypeForAthlete(idAthlete);
        }

        // GET: api/Training/idTraining
        [HttpDelete]
        public ActionResult<Training> DeleteTraining(Int32 idTraining)
        {
            trainingService.Delete(idTraining);
            return Ok();
        }

        // POST: api/training
        [HttpPost]
        public ActionResult<Training> AddTraining(Training training)
        {
            Training obj;
            if (training.IdTraining != 0)
            {
                obj = trainingService.FindById(training.IdTraining);
                if (obj == null)
                    return NoContent();
                else
                {
                    trainingService.Update(training);
                }
            }
            else
            {
                obj = trainingService.Add(training);
            }
            return Ok(obj);
        }


        // GET: api/Training/firsst?idAthlete
        [HttpGet]
        [Route("first")]
        public Training GetFirstTraining(Int32 idAthlete)
        {
            return trainingService.GetFirstTraining(idAthlete);
           // return await _context.Training.Where(x => x.IdAthlete == idAthlete && x.TrainingDateTime > DateTime.Now).OrderBy(x => x.TrainingDateTime).FirstAsync();
            //return await _context.Training.Where(x => x.Athlete.IdAthlete == idAthlete && x.TrainingDateTime > DateTime.Now).OrderBy(x => x.TrainingDateTime).FirstAsync();
        }

        // GET: api/Training/counter?idAthlete
        [HttpGet]
        [Route("counter")]
        public Int32 GetCountTraining(Int32 idAthlete)
        {
            return trainingService.GetCountTraining(idAthlete);
            //return await _context.Training.Where(x => x.IdAthlete == idAthlete && x.TrainingDateTime <= DateTime.Now).CountAsync();
            //return await _context.Training.Where(x => x.Athlete.IdAthlete == idAthlete && x.TrainingDateTime <= DateTime.Now).CountAsync();
        }

        // GET: api/Training/counterMonth?idAthlete
        [HttpGet]
        [Route("counterMonth")]
        public Int32 GetCountMonthTraining(Int32 idAthlete)
        {
            return trainingService.GetCountMonthTraining(idAthlete);
            //return await _context.Training.Where(x => x.IdAthlete == idAthlete && x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddMonths(-1)).CountAsync();
            //return await _context.Training.Where(x => x.Athlete.IdAthlete == idAthlete && x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddMonths(-1)).CountAsync();
        }

        // GET: api/Training/counterWeek?idAthlete
        [HttpGet]
        [Route("counterWeek")]
        public Int32 GetCountWeekTraining(Int32 idAthlete)
        {
            return trainingService.GetCountWeekTraining(idAthlete);
            //return await _context.Training.Where(x => x.IdAthlete == idAthlete && x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddDays(-7)).CountAsync();
            //return await _context.Training.Where(x => x.Athlete.IdAthlete == idAthlete && x.TrainingDateTime <= DateTime.Now && x.TrainingDateTime >= DateTime.Now.AddDays(-7)).CountAsync();
        }

        // GET: api/Training/counterMonthType?idAthlete
        [HttpGet]
        [Route("counterMonthType")]
        public IEnumerable<TrainingTypeCountChartDTO> GetCountMonthByTypeTraining(Int32 idAthlete)
        {
            return trainingService.GetCountMonthByTypeTraining(idAthlete);
        
        }

    }
}
