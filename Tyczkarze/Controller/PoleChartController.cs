using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tyczkarze.BusinessLogic.Services;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoleChartController : ControllerBase
    {
        private readonly IPoleService poleService;
        private readonly ApplicationDbContext _context;

        public PoleChartController(ApplicationDbContext context)
        {
            poleService = new PoleService(context);
            _context = context;
        }


        // GET: api/poleChart/IdAthlete
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PoleChartDTO>> GetPolesForChart(Int32 id)
        {
            return Ok(poleService.GetPolesForChart(id));
        }

        // GET: api/pole/last?IdAthlete=
        [HttpGet]
        [Route("last")]
        public ActionResult<IEnumerable<PoleChartDTO>> GetPolesForChartLastTraining(Int32 idAthlete)
        {
            return Ok(poleService.GetPolesForChartLastTraining(idAthlete));
        }

        // GET: api/month/last?IdAthlete=
        [HttpGet]
        [Route("month")]
        public ActionResult<IEnumerable<PoleChartDTO>> GetPolesForChartLastMonth(Int32 idAthlete)
        {
            return Ok(poleService.GetPolesForChartLastMonth(idAthlete));
        }




    }
}
