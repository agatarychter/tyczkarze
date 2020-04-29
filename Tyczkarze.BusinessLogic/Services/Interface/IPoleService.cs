using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;

namespace Tyczkarze.BusinessLogic.Services.Interface
{
    public interface IPoleService
    {
        IEnumerable<Pole> GetAllByIdAthlete(int idAthlete);
        IEnumerable<PoleChartDTO> GetPolesForChart(Int32 id);
        IEnumerable<PoleChartDTO> GetPolesForChartLastTraining(Int32 idAthlete);
        IEnumerable<PoleChartDTO> GetPolesForChartLastMonth(Int32 idAthlete);
        Pole FindById(int idPole);
        void Delete(int idPole);
        Pole Update(Pole pole);
        Pole Add(Pole pole);
    }
}
