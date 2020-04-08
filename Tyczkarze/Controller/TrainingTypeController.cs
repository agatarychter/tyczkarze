using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingTypeController : ControllerBase
    {
        private readonly ITrainingService trainingService;
        private readonly ApplicationDbContext _context;

        public TrainingTypeController(ApplicationDbContext context)
        {
            trainingService = new TrainingService(context);
            _context = context;
        }       
        // GET: api/TrainingType
        [HttpGet]
        public IEnumerable<TrainingType> GetAll()
        {
            return trainingService.GetAllTrainingTypes();
        }
                
        
    }
}
