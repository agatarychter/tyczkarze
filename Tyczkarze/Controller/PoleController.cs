using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.DataAccess.Model;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoleController : ControllerBase
    {
        private readonly IPoleService poleService;
        private readonly ApplicationDbContext _context;

        public PoleController(ApplicationDbContext context)
        {
            poleService = new PoleService(context);
            _context = context;
        }


        // GET: api/pole/IdAthlete
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Pole>> GetPoles(Int32 id)
        {
           return Ok(poleService.GetAllByIdAthlete(id));
        }

        // GET: api/pole?idPole=
        [HttpGet]
        public ActionResult<Pole> GetPole(Int32 idPole)
        {
            return Ok(poleService.FindById(idPole));
        }

        // GET: api/pole/idPole
        [HttpDelete]
        public ActionResult<Pole> DeletePole(Int32 idPole)
        {
            poleService.Delete(idPole);   
            return Ok();
        }

        // POST: api/pole
        [HttpPost]
        public ActionResult<Pole> AddPole(Pole pole)
        {
            Pole obj;
            if (pole.IdPole != 0)
            {
                obj = poleService.Update(pole);
                if(obj == null)
                {
                    return NoContent();
                }
            }
            else
            {
                obj = poleService.Add(pole);
            }
            
            return Ok(obj);
        }


    }
}
