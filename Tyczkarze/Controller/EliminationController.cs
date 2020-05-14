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
    public class EliminationController : ControllerBase
    {
        private readonly IEliminationService eliminationService;
        private readonly ApplicationDbContext _context;

        public EliminationController(ApplicationDbContext context)
        {
            eliminationService = new EliminationService(context);
            _context = context;
        }

        // GET: api/elimination/id(IdCompetition)
        [HttpGet("{id}")]
        public ActionResult<Elimination> GetEliminationByCompetitionID(Int32 id)
        {
            return Ok(eliminationService.GetEliminationByCompetitionID(id));
        }

        // GET: api/elimination?idElimination=
        [HttpGet]
        public ActionResult<Elimination> GetEliminationByID(Int32 idElimination)
        {
            return Ok(eliminationService.FindById(idElimination));
        }


        // GET: api/elimination/IdElimination
        [HttpDelete]
        public ActionResult<Elimination> DeleteElimination(Int32 idElimination)
        {
            eliminationService.Delete(idElimination);
            return Ok();
        }

        // POST: api/elimination
        [HttpPost]
        public ActionResult<Elimination> AddElimination(Elimination elimination)
        {
            Elimination obj;
            if (elimination.IdElimination != 0)
            {
                obj = eliminationService.Update(elimination);
                if (obj == null)
                    return NoContent();
            }
            else
            {
                obj = eliminationService.Add(elimination);
            }
            return Ok(obj);
        }

    }
}
