using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Model.DTO;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class ContestRepository : IContestRepository
    {
        private readonly ApplicationDbContext _context;

        public ContestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contest Add(Contest entity)
        {
            _context.Contest.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        public void Delete(int Id)
        {
            var contest = FindById(Id);
            _context.Contest.Remove(contest);
            _context.SaveChanges();
        }

        public Contest FindById(int Id)
        {
            return _context.Contest.Where(x => x.IdContest == Id).FirstOrDefault();
        }

        public IEnumerable<Contest> GetAll()
        {
            return _context.Contest.ToList();
        }

        public Contest GetContestByCompetitionID(int id)
        {
            return _context.Contest.Where(x => x.IdCompetition == id).FirstOrDefault();
        }

       
        public Contest Update(Contest contest)
        {
            var obj = FindById(contest.IdContest);
            if (obj == null)
                return null;
            else
            {
                obj = contest;
                _context.SaveChanges();
                return obj;
            }
        }

        public Dictionary<string, List<ContestWithCompetitiontDTO>> GetDictionaryContestForAthlete(int idAthlete)
        {
            var result = (from m1 in _context.Competition
                          join m2 in _context.Contest
                           on m1.IdCompetition equals m2.IdCompetition into joinTable
                          where m1.IdAthlete == idAthlete
                          from x in joinTable.DefaultIfEmpty()
                          select new ContestWithCompetitiontDTO
                          (
                              m1.IdCompetition,
                              m1.Name,
                              x.ContestDate,
                              x.Note
                          )).ToList();
            /*var result = (from m1 in _context.Competition
                          join m2 in _context.Contest
                           on new { m1.IdCompetition } equals new
                           {
                               m2.IdCompetition
                           }
                          where m1.IdAthlete == idAthlete
                          select new ContestWithCompetition
                          (
                              m1.IdCompetition,
                              m1.Name,
                              m2.ContestDate,
                              m2.Note
                          )).ToList();*/
            var allDates = result.Select(x => x.ContestDate).Distinct();
            var map = new Dictionary<string, List<ContestWithCompetitiontDTO>>();
            foreach (var date in allDates)
            {
                if (!String.IsNullOrEmpty(date))
                {
                    var allContestFromDate = result.Where(x => x.ContestDate == date).ToList();
                    map.Add(date, allContestFromDate);
                }

            }
            return map;
        }
    }
}
