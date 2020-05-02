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
    public class JumpStatusRepository : IJumpStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public JumpStatusRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public JumpStatus Add(JumpStatus entity)
        {
            _context.JumpStatus.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var toDelete = FindById(Id);
            _context.JumpStatus.Remove(toDelete);
            _context.SaveChanges();
        }

        public JumpStatus FindById(int Id)
        {
            return _context.JumpStatus.Where(x => x.IdJumpStatus == Id).FirstOrDefault();
        }

        public IEnumerable<JumpStatus> GetAll()
        {
            return _context.JumpStatus.ToList();
        }

        public JumpStatus Update(JumpStatus entity)
        {
            var toEdit = FindById(entity.IdJumpStatus);
            toEdit = entity;
            return toEdit;

        }
    }
}
