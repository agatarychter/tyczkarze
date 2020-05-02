using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tyczkarze.DataAccess.Data;
using Tyczkarze.DataAccess.Model;
using Tyczkarze.DataAccess.Repository.Interface;

namespace Tyczkarze.DataAccess.Repository
{
    public class JumpRepository : IJumpRepository
    {
        private readonly ApplicationDbContext _context;

        public JumpRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Jump Add(Jump jump)
        {
            var obj = jump;            
            _context.Jump.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Delete(int Id)
        {
            var jump = FindById(Id);
            _context.Jump.Remove(jump);
            _context.SaveChanges();
        }

        public Jump FindById(int Id)
        {
            return _context.Jump.Where(x => x.IdJump == Id).FirstOrDefault();
        }

        public IEnumerable<Jump> GetAll()
        {
            return _context.Jump.ToList();
        }
        
        public IEnumerable<Jump> GetAllForContest(int idContest)
        {
            return _context.Jump.Where(x => x.IdContest == idContest).OrderBy(x => x.Height).ToList();
        }

        public IEnumerable<Jump> GetAllForElimination(int idElimination)
        {
            return _context.Jump.Where(x => x.IdElimination == idElimination).OrderBy(x => x.Height).ToList();
        }

        public Jump Update(Jump jump)
        {
            var obj = FindById(jump.IdJump);
            if(obj!= null)
            {
                obj = jump;
            }
           
            _context.SaveChanges();
            return obj;
        }       

    
    }
}
