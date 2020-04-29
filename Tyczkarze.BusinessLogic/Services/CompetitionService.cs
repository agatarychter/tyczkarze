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
    public class CompetitionService : ICompetitionService
    {
        private readonly ApplicationDbContext _context;
        private ICompetitionRepository competitionRepository;
        private ICompetitionLevelRepository competitionLevelRepository;
        private ICompetitionAgeCategoryRepository competitionAgeCategoryRepository;

        public CompetitionService(ApplicationDbContext context)
        {
            competitionRepository = new CompetitionRepository(context);
            competitionLevelRepository = new CompetitionLevelRepository(context);
            competitionAgeCategoryRepository = new CompetitionAgeCategoryRepository(context);
            _context = context;
        }

        public Competition Add(Competition entity)
        {
            entity.IdAgeCategory = entity.IdAgeCategory == 0 ? null : entity.IdAgeCategory;
            entity.IdLevel = entity.IdLevel == 0 ? null : entity.IdLevel;
            var obj = competitionRepository.Add(entity);
            return entity;
        }

        public void Delete(int Id)
        {
            competitionRepository.Delete(Id);
        }

        public Competition FindById(int Id)
        {
            return competitionRepository.FindById(Id);
        }

        public IEnumerable<Competition> GetAll()
        {
            return competitionRepository.GetAll();
        }

        public IEnumerable<CompetitionAgeCategory> GetAllAgeCategory()
        {
            return competitionAgeCategoryRepository.GetAll();
        }

        public IEnumerable<Competition> GetAllForAthlete(int id)
        {
            return competitionRepository.GetAllForAthlete(id);
        }

        public IEnumerable<CompetitionLevel> GetAllLevels()
        {
            return competitionLevelRepository.GetAll();
        }

        public Dictionary<string, List<CompetitionWithAgeAndLevelDTO>> GetDictionaryCompetitionForAthlete(int idAthlete)
        {
            return competitionRepository.GetDictionaryCompetitionForAthlete(idAthlete);            
        }

        public Competition GetFirstCompetition(int idAthlete)
        {
            return competitionRepository.GetAllForAthlete(idAthlete).Where( x => x.BeginDate > DateTime.Now).OrderBy(x => x.BeginDate).FirstOrDefault();
        }

        public Competition Update(Competition competiton)
        {
            var obj = FindById(competiton.IdCompetition);
            if (obj == null)
                return null;
            else
            {
                obj.BeginDate = competiton.BeginDate;
                obj.City = competiton.City;
                obj.Country = competiton.Country;
                obj.EndDate = competiton.EndDate;
                obj.IdAgeCategory = competiton.IdAgeCategory == 0 ? null : competiton.IdAgeCategory;
                obj.IdAthlete = obj.IdAthlete;
                obj.IdLevel = competiton.IdLevel == 0 ? null : competiton.IdLevel;
                obj.Name = competiton.Name;
                obj.Note = competiton.Note;
                competitionRepository.Update(competiton);
                return obj;
            }
        }
    }
}
