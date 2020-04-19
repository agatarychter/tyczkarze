using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tyczkarze.DataAccess.Model.DTO
{
    public class AthleteSettingsDTO
    {
      
        public Int32 IdAthlete { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        

        public DateTime? DateOfBirth { get; set; }
        
        public decimal? Height { get; set; }
        
        public decimal? Weight { get; set; }
    }
}
