using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;
using Tyczkarze.DataAccess.Repository;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.BusinessLogic.Services
{
    public class ContestService : IContestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IContestRepository contestRepository;

        public ContestService(ApplicationDbContext context)
        {
            contestRepository = new ContestRepository(context);
            _context = context;
        }

        public Contest Add(Contest entity)
        {
            return contestRepository.Add(entity);

        }

        public void Delete(int Id)
        {
            contestRepository.Delete(Id);
        }

        public Contest FindById(int Id)
        {
            return contestRepository.FindById(Id);
        }

        public IEnumerable<Contest> GetAll()
        {
            return contestRepository.GetAll();
        }

        public Contest GetContestByCompetitionID(int id)
        {
            return contestRepository.GetContestByCompetitionID(id);
        }

        public Dictionary<string, List<ContestWithCompetitiontDTO>> GetDictionaryContestForAthlete(int idAthlete)
        {
            return contestRepository.GetDictionaryContestForAthlete(idAthlete);
        }

        public Contest Update(Contest contest)
        {
            var obj = FindById(contest.IdContest);
            if (obj == null)
                return null;
            else
            {
                obj.ContestDate = contest.ContestDate;
                obj.IdCompetition = obj.IdCompetition;
                obj.Note = contest.Note;
                var result = contestRepository.Update(obj);
                return result;
            }
        }
    }
}
