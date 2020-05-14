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
    public class ContestController : ControllerBase
    {
        private readonly IContestService contestService;
        private readonly ApplicationDbContext _context;

        public ContestController(ApplicationDbContext context)
        {
            contestService = new ContestService(context);
            _context = context;
        }

        // GET: api/Contest/id(idCompetition)
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Contest>> GetContestByCompetitionID(Int32 id)
        {
            return Ok(contestService.GetContestByCompetitionID(id));
        }
        // GET: api/contest?idContest=
        [HttpGet]
        public ActionResult<Contest> GetContestByID(Int32 idContest)
        {
            return Ok(contestService.FindById(idContest));
        }


        // GET: api/Contest/idContest
        [HttpDelete]
        public ActionResult<ExerciseDone> DeleteContest(Int32 idContest)
        {
            contestService.Delete(idContest);
            return Ok();
        }

        // POST: api/Contest
        [HttpPost]
        public ActionResult<Contest> AddOrUpdateContest(Contest contest)
        {
            Contest obj;
            if (contest.IdContest != 0)
            {
                obj = contestService.Update(contest);
                if (obj == null)
                    return NoContent();
            }
            else
            {
                obj = contestService.Add(contest);
            }
            return Ok(obj);
        }

        // GET: api/contest/contest?idAthlete=
        [HttpGet]
        [Route("contest")]
        public Dictionary<string, List<ContestWithCompetitiontDTO>> GetDictionaryContestForAthlete(Int32 idAthlete)
        {
            return contestService.GetDictionaryContestForAthlete(idAthlete);
        }

    }
}
