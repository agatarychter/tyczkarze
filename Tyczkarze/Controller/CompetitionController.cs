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
    public class CompetitionController : ControllerBase
    {

        private ICompetitionService competitionService;
        private readonly ApplicationDbContext _context;

        public CompetitionController(ApplicationDbContext context)
        {
            competitionService = new CompetitionService(context);
            _context = context;
        }

        // GET: api/Competition/idAthlete
        [HttpGet("{id}")]
        public IEnumerable<Competition> GetAllForAthlete(Int32 id)
        {
            return competitionService.GetAllForAthlete(id);
        }

        // GET: api/Competition?idCompetition
        [HttpGet]
        public Competition GetById(Int32 idCompetition)
        {
            return competitionService.FindById(idCompetition);
        }

        // GET: api/Competition?idAthlete=
        [HttpGet]
        [Route("competitions")]
        public Dictionary<string, List<CompetitionWithAgeAndLevelDTO>> GetDictionaryCompetitionForAthlete(Int32 idAthlete)
        {
            return competitionService.GetDictionaryCompetitionForAthlete(idAthlete);

        }


        // GET: api/Competition/idCompetition
        [HttpDelete]
        public ActionResult<Competition> DeleteCompetition(Int32 idCompetition)
        {
            competitionService.Delete(idCompetition);
            return Ok();
        }

        // POST: api/Competition
        [HttpPost]
        public ActionResult<Competition> AddCompetition(Competition competiton)
        {
            Competition obj;
            if (competiton.IdCompetition != 0)
            {
                obj = competitionService.Update(competiton);
                if (obj == null)
                    return NoContent();                
            }
            else
            {
                obj = competitionService.Add(competiton);
            }
            
            return Ok(obj);
        }

        // GET: api/competition/first?idAthlete=
        [HttpGet]
        [Route("first")]
        public Competition GetFirstCompetition(Int32 idAthlete)
        {
            return competitionService.GetFirstCompetition(idAthlete);
        }

    }
}
