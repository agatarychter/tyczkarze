using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.BusinessLogic.Services.Interface;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Repository;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.BusinessLogic.Services
{
    public class EliminationService : IEliminationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEliminationRepository eliminationRepository;

        public EliminationService(ApplicationDbContext context)
        {
            _context = context;
            eliminationRepository = new  EliminationRepository(context);
        }

        public Elimination Add(Elimination entity)
        {
            return eliminationRepository.Add(entity);
        }

        public void Delete(int Id)
        {
            eliminationRepository.Delete(Id);
        }

        public Elimination FindById(int Id)
        {
            return eliminationRepository.FindById(Id);
        }

        public IEnumerable<Elimination> GetAll()
        {
            return eliminationRepository.GetAll();
        }

        public Elimination GetEliminationByCompetitionID(int id)
        {
            return eliminationRepository.GetEliminationByCompetitionID(id);
        }

        public Elimination Update(Elimination elimination)
        {
            var obj = FindById(elimination.IdElimination);
            if (obj == null)
                return null;
            else
            {

                obj.EliminationDate = elimination.EliminationDate;
                obj.IdCompetition = obj.IdCompetition;
                obj.Note = elimination.Note;
                var result = eliminationRepository.Update(obj);
                return result;
            }
        }
    }
}
