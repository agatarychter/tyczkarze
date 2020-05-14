using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    public class JumpController : ControllerBase
    {

        private readonly IJumpService jumpService;
        private readonly ApplicationDbContext _context;

        public JumpController(ApplicationDbContext context)
        {
            jumpService = new JumpService(context);
            _context = context;
        }


        // GET: api/Jump/idJump
        [HttpGet("{id}")]
        public Jump GetById(Int32 id)
        {
            return jumpService.FindById(id);
        }


        // GET: api/Jump/contest/id
        [HttpGet]
        [Route("contest")]
        public IEnumerable<Jump> GetByAllForContest(Int32 idContest)
        {
            return jumpService.GetAllForContest(idContest);
        }

       

        // GET: api/Jump/elimination/id
        [HttpGet]
        [Route("elimination")]
        public IEnumerable<Jump> GetAllForElimination(Int32 idElimination)
        {
            return jumpService.GetAllForElimination(idElimination);
        }

       

        // GET: api/Jump/idJump
        [HttpDelete]
        public ActionResult<Jump> DeleteJump(Int32 idJump)
        {
            jumpService.Delete(idJump);
            return Ok();
        }

        // POST: api/Jump
        [HttpPost]
        public ActionResult<Jump> AddJump(Jump jump)
        {
            Jump obj;
            if (jump.IdJump != 0)
            {
                obj = jumpService.Update(jump);
            }
            else
            {
                obj = jumpService.Add(jump);
            }
            
            return Ok(obj);
        }

        // POST: api/Jump
        [HttpPost]
        [Route("verify")]
        public ActionResult<String> VerifyJumps(IEnumerable<Jump> jumps)
        {

            var result = jumpService.VerifyJumps(jumps);
            return Ok(result ?? "");
        }


        // GET: api/Jump/bestResult/id
        [HttpGet]
        [Route("bestResult")]
        public JumpDTO GetBestResultForAthlete(Int32 idAthlete)
        {
            return jumpService.GetBestResultForAthlete(idAthlete);
        }

        // GET: api/Jump/winter/id
        [HttpGet]
        [Route("winter")]
        public IEnumerable<JumpChartDTO> GetJumpsForChartWinter(Int32 idAthlete)
        {
            return jumpService.GetJumpsForChartWinter(idAthlete);
        }

        // GET: api/Jump/summer/id
        [HttpGet]
        [Route("summer")]
        public IEnumerable<JumpChartDTO> GetJumpsForChartSummer(Int32 idAthlete)
        {
            return jumpService.GetJumpsforChartSummer(idAthlete);
        }

        // GET: api/Jump/autumn/id
        [HttpGet]
        [Route("autumn")]
        public IEnumerable<JumpChartDTO> GetPolesForChartAutumn(Int32 idAthlete)
        {
            return jumpService.GetJumpsForChartAutumn(idAthlete);
        }

        #region nieużywane

        /*// GET: api/Jump/idJump
       [HttpGet("{id}")]
       public JumpDTO GetById(Int32 id)
       {
           var jump = _context.Jump.Where(x => x.IdJump == id).FirstOrDefault();
           return GetJumpDTO(jump);
       }*/



        /*
       private JumpDTO GetJumpDTO(Jump jump)
       {
           var jumpStatusPole = _context.JumpStatusPole.Where(x => x.IdJump == jump.IdJump).OrderBy(x => x.Order).ToList();
           JumpDTO result = new JumpDTO()
           {
               IdJump = jump.IdJump,
               Height = jump.Height,
               IdContest = jump.IdContest,
               IdElimination = jump.IdElimination,
               JumpType = jump.JumpType,
               Note = jump.Note,
               StepsCount = jump.StepsCount,
               IdJumpStatus1 = 0,
               IdJumpStatus2 = 0,
               IdJumpStatus3 = 0,
               IdPole1 = 0,
               IdPole2 = 0,
               IdPole3 = 0
           };
           for (var i = 0; i < jumpStatusPole.Count; i++)
           {
               if (i == 0)
               {
                   result.IdPole1 = jumpStatusPole[i].IdPole ?? 0;
                   result.IdJumpStatus1 = jumpStatusPole[i].IdJumpStatus ?? 0;
               }
               else if (i == 1)
               {
                   result.IdPole2 = jumpStatusPole[i].IdPole ?? 0;
                   result.IdJumpStatus2 = jumpStatusPole[i].IdJumpStatus ?? 0;
               }
               else if (i == 3)
               {
                   result.IdPole3 = jumpStatusPole[i].IdPole?? 0;
                   result.IdJumpStatus3 = jumpStatusPole[i].IdJumpStatus ?? 0;
               }
           }
           return result;
       }*/

        /* // GET: api/Jump/contest/id
         [HttpGet]
         [Route("contest")]
         public IEnumerable<JumpDTO> GetByAllForContest(Int32 idContest)
         {
             var jumps = _context.Jump.Where(x => x.IdContest == idContest).ToList();
             var resultList = new List<JumpDTO>();
             foreach (var jump in jumps)
             {
                 resultList.Add(GetJumpDTO(jump));
             }

             return resultList;
         }



         // GET: api/Jump/elimination/id
         [HttpGet]
         [Route("elimination")]
         public IEnumerable<JumpDTO> GetByAllForElimination(Int32 idElimination)
         {
             var jumps = _context.Jump.Where(x => x.IdElimination == idElimination).ToList();
             var resultList = new List<JumpDTO>();
             foreach (var jump in jumps)
             {
                 resultList.Add(GetJumpDTO(jump));
             }

             return resultList;
         }



         // GET: api/Jump/idJump
         [HttpDelete]
         public ActionResult<JumpDTO> DeleteJump(Int32 idJump)
         {
             var jump = _context.Jump.Where(c => c.IdJump == idJump).FirstOrDefault();
             var jumpStatusPole = _context.JumpStatusPole.Where(x => x.IdJump == jump.IdJump).OrderBy(x => x.Order).ToList();
             foreach (var jsp in jumpStatusPole)
             {
                 _context.JumpStatusPole.Remove(jsp);
             }
             _context.Jump.Remove(jump);
             _context.SaveChanges();
             return Ok();
         }

         // POST: api/Jump
         [HttpPost]
         public async Task<ActionResult<Jump>> AddJump(JumpDTO jumpDTO)
         {
             Jump obj;
             if (jumpDTO.IdJump != 0)
             {
                 var jump = _context.Jump.Where(x => x.IdJump == jumpDTO.IdJump).FirstOrDefault();
                 var jumpStatusPole = _context.JumpStatusPole.Where(x => x.IdJump == jump.IdJump).OrderBy(x => x.Order).ToList();
                 for (var i = 0; i < jumpStatusPole.Count; i++)
                 {
                     if (i == 0)
                     {
                         jumpStatusPole[i].IdPole = jumpDTO.IdPole1 == null || jumpDTO.IdPole1 == 0 ? null : jumpDTO.IdPole1;
                         jumpStatusPole[i].IdJumpStatus = jumpDTO.IdJumpStatus1 == null || jumpDTO.IdJumpStatus1 == 0 ? null : jumpDTO.IdJumpStatus1;
                     }
                     else if (i == 1)
                     {
                         jumpStatusPole[i].IdPole = jumpDTO.IdPole2 == null || jumpDTO.IdPole2 == 0 ? null : jumpDTO.IdPole2;
                         jumpStatusPole[i].IdJumpStatus = jumpDTO.IdJumpStatus2 == null || jumpDTO.IdJumpStatus2 == 0 ? null : jumpDTO.IdJumpStatus2;
                     }
                     else if (i == 3)
                     {
                         jumpStatusPole[i].IdPole = jumpDTO.IdPole3 == null || jumpDTO.IdPole3 == 0 ? null : jumpDTO.IdPole3;
                         jumpStatusPole[i].IdJumpStatus = jumpDTO.IdJumpStatus3 == null || jumpDTO.IdJumpStatus3 == 0 ? null : jumpDTO.IdJumpStatus3;

                     }
                 }
                 jump.Height = jumpDTO.Height;
                 jump.IdContest = jump.IdContest;
                 jump.IdElimination = jump.IdElimination;
                 jump.JumpType = jumpDTO.JumpType;
                 jump.Note = jumpDTO.Note;
                 jump.StepsCount = jumpDTO.StepsCount;
                 obj = jump;
             }
             else
             {
                 Jump jumpToSave = new Jump() { JumpType = jumpDTO.JumpType, Note = jumpDTO.Note, StepsCount = jumpDTO.StepsCount, Height = jumpDTO.Height, IdElimination = jumpDTO.IdElimination, IdContest = jumpDTO.IdContest };
                 _context.Jump.Add(jumpToSave);
                 _context.SaveChanges();
                 var id = jumpToSave.IdJump;

                 JumpStatusPole jumpStatusPole = new JumpStatusPole() { IdJump = id, IdJumpStatus = jumpDTO.IdJumpStatus1 == null || jumpDTO.IdJumpStatus1 == 0 ? null : jumpDTO.IdJumpStatus1, IdPole = jumpDTO.IdPole1 == null || jumpDTO.IdPole1 == 0 ? null : jumpDTO.IdPole1, Order = 1 };
                 _context.JumpStatusPole.Add(jumpStatusPole);

                 JumpStatusPole jumpStatusPole1 = new JumpStatusPole() { IdJump = id, IdJumpStatus = jumpDTO.IdJumpStatus2 == null || jumpDTO.IdJumpStatus2 == 0 ? null : jumpDTO.IdJumpStatus2, IdPole = jumpDTO.IdPole2 == null || jumpDTO.IdPole2 == 0 ? null : jumpDTO.IdPole2, Order = 2 };
                 _context.JumpStatusPole.Add(jumpStatusPole1);
                 JumpStatusPole jumpStatusPole2 = new JumpStatusPole() { IdJump = id, IdJumpStatus = jumpDTO.IdJumpStatus3 == null || jumpDTO.IdJumpStatus3 == 0 ? null : jumpDTO.IdJumpStatus3, IdPole = jumpDTO.IdPole3 == null || jumpDTO.IdPole3 == 0 ? null : jumpDTO.IdPole3, Order = 3 };
                 _context.JumpStatusPole.Add(jumpStatusPole2);




                 obj = jumpToSave;
             }

             await _context.SaveChangesAsync();
             return Ok(obj);
         }*/

        #endregion

    }
}
