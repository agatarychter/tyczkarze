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
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly ApplicationDbContext _context;

        public CompetitionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Competition Add(Competition entity)
        {           
            _context.Competition.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var competiton = FindById(Id);
            var elimination = _context.Elimination.Where(x => x.IdCompetition == competiton.IdCompetition);
            var contest = _context.Contest.Where(x => x.IdCompetition == competiton.IdCompetition);
            foreach (var obj in elimination)
            {
                var jumps = _context.Jump.Where(x => x.IdElimination == obj.IdElimination).ToList();
                foreach(var j in jumps)
                {
                    _context.Jump.Remove(j);
                }
                _context.Elimination.Remove(obj);
            }
            foreach (var obj in contest)
            {
                var jumps = _context.Jump.Where(x => x.IdContest == obj.IdContest).ToList();
                foreach (var j in jumps)
                {
                    _context.Jump.Remove(j);
                }
                _context.Contest.Remove(obj);
            }
            _context.Competition.Remove(competiton);
            _context.SaveChanges();
        }

        public Competition FindById(int Id)
        {
            return _context.Competition.Where(x => x.IdCompetition == Id).FirstOrDefault();
        }

        public IEnumerable<Competition> GetAll()
        {
            return _context.Competition.ToList();
        }

       

        public IEnumerable<Competition> GetAllForAthlete(int id)
        {
            return _context.Competition.Where(x => x.IdAthlete == id).ToList();
        }

        public Dictionary<string, List<CompetitionWithAgeAndLevelDTO>> GetDictionaryCompetitionForAthlete(int idAthlete)
        {
            var result1 = (from m1 in _context.Competition
                           join m2 in _context.CompetitionAgeCategory
                            on m1.IdAgeCategory equals m2.IdAgeCategory into joinTable
                           from x2 in joinTable.DefaultIfEmpty()
                           join m3 in _context.CompetitionLevel on m1.IdLevel equals m3.IdLevel into joinTable2
                           where m1.IdAthlete == idAthlete
                           from x in joinTable2.DefaultIfEmpty()
                           select new CompetitionWithAgeAndLevelDTO
                           ()
                           {
                               IdCompetition = m1.IdCompetition,
                               ResultType = 1,
                               BeginDate = m1.BeginDate.HasValue ? m1.BeginDate.Value.ToShortDateString() : null,
                               EndDate = m1.EndDate.HasValue ? m1.EndDate.Value.ToShortDateString() : null,
                               Country = m1.Country,
                               City = m1.City,
                               Name = m1.Name,
                               NameAgeCategory = x2.NameAgeCategory,
                               LevelName = x.LevelName,
                               CommonDate = m1.BeginDate.HasValue ? m1.BeginDate.Value.ToShortDateString() : null,

                           }).ToList();
            var cos = result1;
            List<CompetitionWithAgeAndLevelDTO> newForCompetition = new List<CompetitionWithAgeAndLevelDTO>();
            for (int i = 0; i < cos.Count; i++)
            {
                if (cos[i].EndDate != null && cos[i].BeginDate != null)
                {
                    DateTime end = DateTime.Parse(cos[i].EndDate);
                    DateTime begin = DateTime.Parse(cos[i].BeginDate);
                    var countDiff = (end - begin).TotalDays;
                    if (countDiff > 0)
                    {
                        while (countDiff > 0)
                        {
                            newForCompetition.Add(
                                new CompetitionWithAgeAndLevelDTO()
                                {
                                    IdCompetition = cos[i].IdCompetition,
                                    ResultType = 1,
                                    BeginDate = begin.ToShortDateString(),
                                    EndDate = end.ToShortDateString(),
                                    Country = cos[i].Country,
                                    City = cos[i].City,
                                    Name = cos[i].Name,
                                    NameAgeCategory = cos[i].NameAgeCategory,
                                    LevelName = cos[i].LevelName,
                                    CommonDate = begin.AddDays(countDiff).ToShortDateString(),

                                });
                            countDiff--;

                        }
                    }

                }
            }

            var result2 = (from m1 in _context.Competition
                           join m2 in _context.Contest
                            on m1.IdCompetition equals m2.IdCompetition into joinTable
                           where m1.IdAthlete == idAthlete
                           from x in joinTable.DefaultIfEmpty()
                           select new CompetitionWithAgeAndLevelDTO
                           ()
                           {
                               IdCompetition = m1.IdCompetition,
                               ResultType = 2,
                               Name = m1.Name,
                               ContestDate = x.ContestDate.ToShortDateString() ?? null,
                               DescriptionContest = x.Note,
                               IdContest = x.IdContest,
                               CommonDate = x.ContestDate.ToShortDateString() ?? null,
                           }
                          ).ToList();
            var result3 = (from m1 in _context.Competition
                           join m2 in _context.Elimination
                            on m1.IdCompetition equals m2.IdCompetition into joinTable
                           where m1.IdAthlete == idAthlete
                           from x in joinTable.DefaultIfEmpty()
                           select new CompetitionWithAgeAndLevelDTO
                           ()
                           {
                               IdCompetition = m1.IdCompetition,
                               ResultType = 3,
                               Name = m1.Name,
                               ContestDate = x.EliminationDate.ToShortDateString() ?? null,
                               DescriptionElimination = x.Note,
                               IdElimination = x.IdElimination,
                               CommonDate = x.EliminationDate.ToShortDateString() ?? null,
                           }
                          ).ToList();
            var result4 = result1.Concat(result2);
            var result5 = result4.Concat(result3);
            var result = result5.Concat(newForCompetition);
            var allDates = result.Select(x => x.CommonDate).Distinct();
            var map = new Dictionary<string, List<CompetitionWithAgeAndLevelDTO>>();
            foreach (var date in allDates)
            {
                if (!String.IsNullOrEmpty(date))
                {
                    var allCompetitionFromDate = result.Where(x => x.CommonDate == date).ToList();
                    map.Add(date, allCompetitionFromDate);
                }

            }
            return map;
        }

        public Competition Update(Competition competiton)
        {
            var obj = FindById(competiton.IdCompetition);
            if (obj == null)
                return null;
            else
            {
                obj = competiton;
                _context.SaveChanges();
                return obj;
            }
        }
    }
}
