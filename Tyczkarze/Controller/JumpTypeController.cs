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
    public class JumpTypeController : ControllerBase
    {

        private readonly IJumpService jumpService;
        private readonly ApplicationDbContext _context;

        public JumpTypeController(ApplicationDbContext context)
        {
            jumpService = new JumpService(context);
            _context = context;
        }

        // GET: api/CompetitionAgeCategory
        [HttpGet]
        public IEnumerable<JumpType> GetAll()
        {
            return jumpService.GetAllJumpTypes();
        }


    }
}
