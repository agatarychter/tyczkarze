using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class AthleteLoginDTO
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string GUID { get; set; }
    }
}
