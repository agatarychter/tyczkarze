using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuidController : ControllerBase
    {
        private readonly IAthleteService athleteService;
        private readonly ApplicationDbContext _context;

        public GuidController(ApplicationDbContext context)
        {
            athleteService = new AthleteService(context);
            _context = context;
        }
        // GET: api/guid/id
        [HttpPost("{id}")]
        public ActionResult<Athlete> RemoveAthleteGuid(Int32 id)
        {
            var athlete = athleteService.RemoveAthleteGuid(id);
            if (athlete == null)
            {
                return NotFound();
            }
            return athlete;
        }

        // POST: api/guid
        [HttpPost]
        public ActionResult<Athlete> VerifyAthleteByGuid(String guid)
        {

            var athleteGuid = athleteService.VerifyAthleteByGuid(guid);         

            if(athleteGuid != null)
            {
                return Ok(athleteGuid);
            }
            else
            {    
                  return NotFound();
                
            }         
            
        }

    }
}

