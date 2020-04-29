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
    public class CompetitionAgeCategoryController : ControllerBase
    {

        private ICompetitionService competitionService;
        private readonly ApplicationDbContext _context;

        public CompetitionAgeCategoryController(ApplicationDbContext context)
        {
            competitionService = new CompetitionService(context);
            _context = context;
        }

        // GET: api/CompetitionAgeCategory
        [HttpGet]
        public IEnumerable<CompetitionAgeCategory> GetAll()
        {
            return competitionService.GetAllAgeCategory();
        }


    }
}
