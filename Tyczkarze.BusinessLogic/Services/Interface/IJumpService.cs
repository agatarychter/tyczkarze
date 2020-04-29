using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface IJumpService
    {
        IEnumerable<JumpType> GetAllJumpTypes();
        IEnumerable<JumpStatus> GetAllJumpStatuses();
        IEnumerable<Jump> GetAllForContest(Int32 idContest);
        IEnumerable<Jump> GetAllForElimination(Int32 idElimination);
        IEnumerable<Jump> GetAllForAthlete(Int32 idAthlete);

        String VerifyJumps(IEnumerable<Jump> jumps);

        JumpDTO GetBestResultForAthlete(Int32 idAthlete);

        IEnumerable<JumpChartDTO> GetJumpsForChartWinter(Int32 id);
        IEnumerable<JumpChartDTO> GetJumpsforChartSummer(Int32 idAthlete);
        IEnumerable<JumpChartDTO> GetJumpsForChartAutumn(Int32 idAthlete);
        Jump FindById(int id);
        void Delete(int idJump);
        Jump Update(Jump jump);
        Jump Add(Jump jump);
    }
}
