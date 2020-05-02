using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class CompetitionAgeCategoryRepository : ICompetitionAgeCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CompetitionAgeCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public CompetitionAgeCategory Add(CompetitionAgeCategory entity)
        {
            _context.CompetitionAgeCategory.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var obj = FindById(Id);
            if (obj != null)
                _context.CompetitionAgeCategory.Remove(obj);
            _context.SaveChanges();
        }

        public CompetitionAgeCategory FindById(int Id)
        {
            return _context.CompetitionAgeCategory.Where(x => x.IdAgeCategory == Id).FirstOrDefault();
        }

        public IEnumerable<CompetitionAgeCategory> GetAll()
        {
            return _context.CompetitionAgeCategory.ToList();
        }

        public CompetitionAgeCategory Update(CompetitionAgeCategory entity)
        {
            var obj = FindById(entity.IdAgeCategory);
            if (obj != null)
                obj = entity;
            _context.SaveChanges();
            return obj;
        }
    }
}
