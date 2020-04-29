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

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionLevelController : ControllerBase
    {

        private readonly ICompetitionService competitionService;
        private readonly ApplicationDbContext _context;

        public CompetitionLevelController(ApplicationDbContext context)
        {
            competitionService = new CompetitionService(context);
            _context = context;
        }

        // GET: api/CompetitionLevel
        [HttpGet]
        public IEnumerable<CompetitionLevel> GetAll()
        {
            return competitionService.GetAllLevels();
        }


    }
}
