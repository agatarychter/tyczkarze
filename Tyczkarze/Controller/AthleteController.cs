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
using Tyczkarze.DataAccess.Repository;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {
        private IAthleteService athleteService;
        private readonly ApplicationDbContext _context;

        public AthleteController(ApplicationDbContext context)
        {
            athleteService = new AthleteService(context);
            _context = context;
        }

        // GET: api/zawodnik
        [HttpGet]
        public ActionResult<IEnumerable<Athlete>> GetAthlets()
        {
            return Ok(athleteService.GetAll());
        }


        // GET: api/zawodnik/5
        [HttpGet("{id}")]
        public ActionResult<Athlete> GetAthlete(Int32 id)
        {
            var athlete = athleteService.FindById(id);
            if (athlete == null)
            {
                return NotFound();
            }
            return athlete;
        }

        // POST: api/athlete/verify
        [HttpPost]
        [Route("verify")]
        public ActionResult<Athlete> VerifyUser(AthleteLoginDTO user)
        {
            var result = athleteService.VerifyAthlete(user);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }    
        }


        // POST: api/athlete
        [HttpPost]
        public ActionResult<Athlete> AddAthlete(Athlete athlete)
        {
            Athlete obj;
            if (athlete.IdAthlete != 0)
            {
                obj = athleteService.Update(athlete);
                if(obj == null)
                {
                    return NoContent();
                }
            }
            else
            {
                var possibleExist = athleteService.GetByEmail(athlete.Email);
                if(possibleExist == null)
                {
                    obj = athleteService.Add(athlete);
                }
                else
                {
                    return Conflict();
                }                
            }
            
            return Ok(obj);
        }
        
    }
}
