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
    public class AthleteService : IAthleteService
    {

        private readonly ApplicationDbContext _context;
        private IAthleteRepository _athleteRepository;

        public Athlete Add(Athlete entity)
        {
            var obj = _athleteRepository.Add(entity);
            return obj;
        }
        public AthleteService(ApplicationDbContext context)
        {
            _context = context;
            _athleteRepository = new AthleteRepository(_context);
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Athlete FindById(int Id)
        {
            return _athleteRepository.FindById(Id);
        }

        public IEnumerable<Athlete> GetAll()
        {
            return _athleteRepository.GetAll();
        }

        public Athlete GetByEmail(string email)
        {
            return _athleteRepository.GetByEmail(email);
        }

        public Athlete RemoveAthleteGuid(int id)
        {
            var athlete = FindById(id);
            if (athlete == null)
            {
                return null;
            }
            else
            {
                athlete.GUID = null;
                _athleteRepository.Update(athlete);
            }
            return athlete;
        }
        public Athlete GetByGuid(string guid)
        {
            return _athleteRepository.GetByGuid(guid);
        }

        public Athlete Update(Athlete athlete)
        {
            var obj = FindById(athlete.IdAthlete);
            if (obj == null)
                return null;
            else
            {
                obj.Name = athlete.Name;
                obj.Surname = athlete.Surname;
                obj.DateOfBirth = athlete.DateOfBirth;
                obj.Height = athlete.Height;
                obj.Weight = athlete.Weight;
                obj.Email = obj.Email;
                obj.GUID = obj.GUID;
                obj.Password = obj.Password;
                _athleteRepository.Update(obj);
                return obj;
            }
        }

        public Athlete VerifyAthlete(AthleteLoginDTO user)
        {
            var athleteWithEmail = GetByEmail(user.Email);
            if (athleteWithEmail != null)
            {
                var withPassword = athleteWithEmail.Password == user.Password;
                if (withPassword)
                {
                    athleteWithEmail.GUID = user.GUID;
                    _athleteRepository.Update(athleteWithEmail);
                    return athleteWithEmail;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public Athlete VerifyAthleteByGuid(string guid)
        {
            var athleteGuid = GetByGuid(guid);
            if (athleteGuid != null)
            {
                return athleteGuid;
            }
            else
            {
                return null;
            }
        }
    }
}
