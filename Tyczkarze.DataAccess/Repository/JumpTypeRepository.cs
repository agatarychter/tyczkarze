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
    public class JumpTypeRepository : IJumpTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public JumpTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public JumpType Add(JumpType entity)
        {
            _context.JumpType.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int Id)
        {
            var toDelete = FindById(Id);
            _context.JumpType.Remove(toDelete);
            _context.SaveChanges();
        }

        public JumpType FindById(int Id)
        {
            return _context.JumpType.Where(x => x.IdJumpType == Id).FirstOrDefault();
        }

        public IEnumerable<JumpType> GetAll()
        {
            return _context.JumpType.ToList();
        }

        public JumpType Update(JumpType entity)
        {
            var toEdit = FindById(entity.IdJumpType);
            toEdit = entity;
            return toEdit;
        }
    }
}
