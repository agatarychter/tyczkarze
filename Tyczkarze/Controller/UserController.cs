using Microsoft.AspNetCore.Mvc;
using System;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAthleteService athleteService;
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            athleteService = new AthleteService(context);
            _context = context;
        }



        // POST: api/user
        [HttpPost]
        public ActionResult<Athlete> VerifyUser(AthleteLoginDTO user)
        {
            var athlete = athleteService.VerifyAthlete(user);
            if(athlete == null)
                return NotFound();
            return Ok(athlete);

        }

    }
}
